using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using BicycleSales.DAL;
using BicycleSales.DAL.Interfaces;

namespace BicycleSales.BLL;

public class ShipmentManager : IShipmentManager
{
    private readonly IMapperBLL _mapper;
    private readonly IShipmentRepository _shipmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShopRepository _shopRepository;
    private readonly IProductRepository _productRepository;

    public ShipmentManager(IMapperBLL mapper = null, IShipmentRepository shipmentRepository = null,
        IUserRepository userRepository = null, IShopRepository shopRepository = null, IProductRepository productRepository = null)
    {
        _mapper = mapper ?? new MapperBLL();
        _shipmentRepository = shipmentRepository ?? new ShipmentRepository();
        _userRepository = userRepository ?? new UserRepository();
        _shopRepository = shopRepository ?? new ShopRepository();
        _productRepository = productRepository ?? new ProductRepository();
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

        callback.FormedBy = _userRepository.GetUserById(callback.FormedById);
        callback.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.FormedBy.AuthorizationId);
        callback.FormedBy.Shop = await _shopRepository.GetShopById(callback.FormedBy.ShopId);
        callback.Shop = await _shopRepository.GetShopById(callback.ShopId);

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

        var dto = _mapper.MapShipmentProductToShipmentProductDto(shipmentProduct);
        var callback = _shipmentRepository.AddProductToShipment(dto);

        callback.Shipment = _shipmentRepository.GetShipmentById(shipmentProduct.ShipmentId);
        callback.Shipment.FormedBy = _userRepository.GetUserById(callback.Shipment.FormedById);
        callback.Shipment.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.Shipment.FormedBy.AuthorizationId);
        callback.Shipment.FormedBy.Shop = await _shopRepository.GetShopById(callback.Shipment.FormedBy.ShopId);
        callback.Shipment.Shop = await _shopRepository.GetShopById(callback.Shipment.ShopId);
        callback.Product = await _productRepository.GetProductByIdAsync(callback.ProductId);

        var result = _mapper.MapShipmentProductDtoToShipmentProduct(callback);

        return result;
    }

    public async Task<ShipmentProduct> UpdateProductInShipment(ShipmentProduct shipmentProduct)
    {
        if (!_shipmentRepository.IsShipmentExist(shipmentProduct.ShipmentId))
            throw new ObjectNotExistException("Shipment", shipmentProduct.ShipmentId);
        if (!_productRepository.IsProductExist(shipmentProduct.ProductId))
            throw new ObjectNotExistException("Product", shipmentProduct.ProductId);
        if (_shipmentRepository.IsFactCountAlreadyAdded(shipmentProduct.ShipmentId, shipmentProduct.ProductId))
            throw new RepetativeActionException("Adding", "Fact Product Count");
        if (shipmentProduct.FactProductCount < 0)
            throw new ArgumentOutOfRangeException("", "Fact Product count must be non negative");

        var dto = _mapper.MapShipmentProductToShipmentProductDto(shipmentProduct);
        var callback = _shipmentRepository.UpdateProductInShipment(dto);

        callback.Shipment = _shipmentRepository.GetShipmentById(shipmentProduct.ShipmentId);
        callback.Shipment.FormedBy = _userRepository.GetUserById(callback.Shipment.FormedById);
        callback.Shipment.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.Shipment.FormedBy.AuthorizationId);
        callback.Shipment.FormedBy.Shop = await _shopRepository.GetShopById(callback.Shipment.FormedBy.ShopId);
        callback.Shipment.Shop = await _shopRepository.GetShopById(callback.Shipment.ShopId);
        callback.Product = await _productRepository.GetProductByIdAsync(callback.ProductId);

        var result = _mapper.MapShipmentProductDtoToShipmentProduct(callback);

        return result;
    }

    public async Task<Shipment> UpdateShipment(Shipment shipment)
    {
        if (!_shipmentRepository.IsShipmentExist(shipment.Id))
            throw new ObjectNotExistException("Shipment", shipment.Id);
        if (!_userRepository.IsUserExist((int)shipment.SignedById!))
            throw new ObjectNotExistException("User", (int)shipment.SignedById!);
        if (_shipmentRepository.IsShipmentSigned(shipment.Id))
            throw new RepetativeActionException("Signed", "Shipment");

        var dto = _mapper.MapShipmentToShipmentDto(shipment);
        dto.FactTime = DateTime.Now;
        var callback = _shipmentRepository.UpdateShipment(dto);

        callback.SignedBy = _userRepository.GetUserById((int)callback.SignedById!);
        callback.SignedBy.Authorization = _userRepository.GetAuthorizationById(callback.SignedBy.AuthorizationId);
        callback.SignedBy.Shop = await _shopRepository.GetShopById(callback.SignedBy.ShopId);
        callback.FormedBy = _userRepository.GetUserById(callback.FormedById);
        callback.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.FormedBy.AuthorizationId);
        callback.FormedBy.Shop = await _shopRepository.GetShopById(callback.FormedBy.ShopId);
        callback.Shop = await _shopRepository.GetShopById(callback.ShopId);

        var result = _mapper.MapShipmentDtoToShipment(callback);

        return result;
    }

    public async Task<Shipment> GetShipmentById(int id)
    {
        if (!_shipmentRepository.IsShipmentExist(id))
            throw new ObjectNotExistException("Shipment", id);

        var callback = _shipmentRepository.GetShipmentById(id);

        callback.SignedBy = _userRepository.GetUserById((int)callback.SignedById!);
        callback.SignedBy.Authorization = _userRepository.GetAuthorizationById(callback.SignedBy.AuthorizationId);
        callback.SignedBy.Shop = await _shopRepository.GetShopById(callback.SignedBy.ShopId);
        callback.FormedBy = _userRepository.GetUserById(callback.FormedById);
        callback.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.FormedBy.AuthorizationId);
        callback.FormedBy.Shop = await _shopRepository.GetShopById(callback.FormedBy.ShopId);
        callback.Shop = await _shopRepository.GetShopById(callback.ShopId);

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