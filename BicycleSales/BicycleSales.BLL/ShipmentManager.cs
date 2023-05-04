using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using BicycleSales.DAL;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BicycleSales.BLL;

public class ShipmentManager : IShipmentManager
{
    private readonly IMapperBLL _mapper;
    private readonly IShipmentRepository _shipmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShopRepository _shopRepository;
    private readonly IProductRepository _productRepository;
    private readonly IShipmentAcceptanceRepository _shipAccRepository;

    public ShipmentManager(IMapperBLL mapper, IShipmentRepository shipmentRepository,
        IUserRepository userRepository, IShopRepository shopRepository,
        IProductRepository productRepository, IShipmentAcceptanceRepository shipAccRepository)
    {
        _mapper = mapper;
        _shipmentRepository = shipmentRepository;
        _userRepository = userRepository;
        _shopRepository = shopRepository;
        _productRepository = productRepository;
        _shipAccRepository = shipAccRepository;
    }

    public async Task<Shipment> CreateNewShipment(Shipment shipment)
    {
        if (!_userRepository.IsUserExist(shipment.FormedById))
            throw new ObjectNotExistException("User", shipment.FormedById);
        if (!_shopRepository.IsShopExist(shipment.ShopId))
            throw new ObjectNotExistException("Shop", shipment.ShopId);
        if (shipment.PlanedTime < DateTime.UtcNow)
            throw new InvalidTimeException(shipment.PlanedTime);

        var dto = _mapper.MapShipmentToShipmentDto(shipment);
        var callback = _shipmentRepository.CreateNewShipment(dto);

        var result = _mapper.MapShipmentDtoToShipment(callback);

        return result;
    }

    public async Task<ShipmentProduct> AddProductToShipment(ShipmentProduct shipmentProduct)
    {
        if (!_shipmentRepository.IsShipmentExist(shipmentProduct.ShipmentId))
            throw new ObjectNotExistException("Shipment", shipmentProduct.ShipmentId);
        if (!_productRepository.IsProductExist(shipmentProduct.ProductId))
            throw new ObjectNotExistException("Product", shipmentProduct.ProductId);
        if (shipmentProduct.ProductCount < 1)
            throw new ArgumentOutOfRangeException("", "Product count must be positive");
        if (_shipmentRepository.IsProductExistInShipment(shipmentProduct.ShipmentId, shipmentProduct.ProductId))
            throw new RepetativeActionException("Adding", "Product");
        if (_shipmentRepository.IsShipmentSigned(shipmentProduct.ShipmentId))
            throw new WorkWithForbiddenResourceException("Shipment", shipmentProduct.Id);

        var dto = _mapper.MapShipmentProductToShipmentProductDto(shipmentProduct);
        var callback = _shipmentRepository.AddProductToShipment(dto);

        var result = _mapper.MapShipmentProductDtoToShipmentProduct(callback);

        return result;
    }

    public async Task<ShipmentProduct> UpdateProductInShipment(ShipmentProduct shipmentProduct)
    {
        if (!_shipmentRepository.IsShipmentExist(shipmentProduct.ShipmentId))
            throw new ObjectNotExistException("Shipment", shipmentProduct.ShipmentId);
        if (!_productRepository.IsProductExist(shipmentProduct.ProductId))
            throw new ObjectNotExistException("Product", shipmentProduct.ProductId);
        if (!_shipmentRepository.IsProductExistInShipment(shipmentProduct.ShipmentId, shipmentProduct.ProductId))
            throw new ObjectNotExistException("Product in Shipment", shipmentProduct.ProductId);
        if (_shipmentRepository.IsFactCountAlreadyAdded(shipmentProduct.ShipmentId, shipmentProduct.ProductId))
            throw new RepetativeActionException("Adding", "Fact Product Count");
        if (shipmentProduct.FactProductCount < 0)
            throw new ArgumentOutOfRangeException("", "Fact Product count must be non negative");

        var dto = _mapper.MapShipmentProductToShipmentProductDto(shipmentProduct);
        var callback = _shipmentRepository.UpdateProductInShipment(dto);

        var result = _mapper.MapShipmentProductDtoToShipmentProduct(callback);

        return result;
    }

    public async Task<Shipment> UpdateShipment(Shipment shipment)
    {
        if (!_shipmentRepository.IsShipmentExist(shipment.Id))
            throw new ObjectNotExistException("Acceptance", shipment.Id);
        if (!_userRepository.IsUserExist((int)shipment.SignedById!))
            throw new ObjectNotExistException("User", (int)shipment.SignedById!);
        if (_shipmentRepository.IsShipmentSigned(shipment.Id))
            throw new RepetativeActionException("Signed", "Shipment");

        var shipmentAcceptance = await _shipAccRepository.GetShipmentAcceptanceAsync(shipment.Id);
        shipmentAcceptance.Status = ShipmentAcceptanceStatus.ShipmentSigned;
        await _shipAccRepository.UpdateShipmentAcceptanceAsync(shipmentAcceptance);

        var shipmentProduct = _shipmentRepository.GetAllProductFromShipmentById(shipmentAcceptance.ShipmentId).ToList();
        var shopProducts = await _shopRepository.GetAllProductsByShopId(shipmentAcceptance.Shipment.ShopId)!;

        foreach (var line in shipmentProduct)
        {
            var product = shopProducts.ToList().Find(x => x.ProductId == line.ProductId)!;
            ShopProductDto deleteProduct = new()
            {
                Id = product.Id,
                ProductCount = (int)line.FactProductCount!,
                ProductId = product.ProductId,
                ShopId = product.ShopId
            };

            await _shopRepository.DeleteProductCountInShopAsync(deleteProduct);
        }

        var dto = _mapper.MapShipmentToShipmentDto(shipment);
        dto.FactTime = DateTime.Now;
        var callback = _shipmentRepository.UpdateShipment(dto);
        var result = _mapper.MapShipmentDtoToShipment(callback);

        return result;
    }

    public async Task<Shipment> GetShipmentById(int id)
    {
        if (!_shipmentRepository.IsShipmentExist(id))
            throw new ObjectNotExistException("Shipment", id);

        var callback = _shipmentRepository.GetShipmentById(id);

        var result = _mapper.MapShipmentDtoToShipment(callback);

        return result;
    }

    public async Task<IEnumerable<ShipmentProduct>> GetAllProductFromShipmentById(int id)
    {
        var callback = _shipmentRepository.GetAllProductFromShipmentById(id);

        foreach (var line in callback)
        {
            line.Product = await _productRepository.GetProductByIdAsync(line.ProductId);
        }

        var result = _mapper.MapShipmentProductDtoListToShipmentProductList(callback);
        return result;
    }
}