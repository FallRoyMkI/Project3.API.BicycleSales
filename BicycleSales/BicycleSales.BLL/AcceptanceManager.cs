using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using BicycleSales.DAL;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.BLL;

public class AcceptanceManager : IAcceptanceManager
{
    private readonly IMapperBLL _mapper;
    private readonly IAcceptanceRepository _acceptanceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShopRepository _shopRepository;
    private readonly IProductRepository _productRepository;


    public AcceptanceManager(IMapperBLL mapper = null, IAcceptanceRepository acceptanceRepository = null,
        IUserRepository userRepository = null, IShopRepository shopRepository = null, IProductRepository productRepository= null)
    {
        _mapper = mapper ?? new MapperBLL();
        _acceptanceRepository = acceptanceRepository ?? new AcceptanceRepository();
        _userRepository = userRepository ?? new UserRepository();
        _shopRepository = shopRepository ?? new ShopRepository();
        _productRepository = productRepository ?? new ProductRepository();
    }

    public Acceptance CreateNewAcceptance(Acceptance acceptance)
    {
        if (!_userRepository.IsUserExist(acceptance.FormedById)) 
            throw new ObjectNotExistException("User", acceptance.FormedById);
        if (!_shopRepository.IsShopExist(acceptance.ShopId)) 
            throw new ObjectNotExistException("Shop", acceptance.ShopId);
        if (acceptance.PlanedTime < DateTime.UtcNow)
            throw new InvalidTimeException(acceptance.PlanedTime);

        var dto = _mapper.MapAcceptanceToAcceptanceDto(acceptance);
        var callback = _acceptanceRepository.CreateNewAcceptance(dto);

        callback.FormedBy = _userRepository.GetUserById(callback.FormedById);
        callback.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.FormedBy.AuthorizationId);
        callback.FormedBy.Shop = _shopRepository.GetShopById(callback.FormedBy.ShopId);
        callback.Shop = _shopRepository.GetShopById(callback.ShopId);

        var result = _mapper.MapAcceptanceDtoToAcceptance(callback);

        return result;
    }

    public AcceptanceProduct AddProductToAcceptance(AcceptanceProduct acceptanceProduct)
    {
        if (!_acceptanceRepository.IsAcceptanceExist(acceptanceProduct.AcceptanceId))
            throw new ObjectNotExistException("Acceptance", acceptanceProduct.AcceptanceId);
        if (!_productRepository.IsProductExist(acceptanceProduct.ProductId))
            throw new ObjectNotExistException("Product", acceptanceProduct.ProductId);
        if (acceptanceProduct.ProductCount < 1) 
            throw new ArgumentOutOfRangeException("", "Product count must be positive");
        if (_acceptanceRepository.IsProductExistInAcceptance(acceptanceProduct.AcceptanceId, acceptanceProduct.ProductId))
            throw new RepetativeActionException("Adding", "Product");

        var dto = _mapper.MapAcceptanceProductToAcceptanceProductDto(acceptanceProduct);
        var callback = _acceptanceRepository.AddProductToAcceptance(dto);

        callback.Acceptance = _acceptanceRepository.GetAcceptanceById(acceptanceProduct.AcceptanceId);
        callback.Acceptance.FormedBy = _userRepository.GetUserById(callback.Acceptance.FormedById);
        callback.Acceptance.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.Acceptance.FormedBy.AuthorizationId);
        callback.Acceptance.FormedBy.Shop = _shopRepository.GetShopById(callback.Acceptance.FormedBy.ShopId);
        callback.Acceptance.Shop = _shopRepository.GetShopById(callback.Acceptance.ShopId);
        callback.Product = _productRepository.GetProductById(callback.ProductId);

        var result = _mapper.MapAcceptanceProductDtoToAcceptanceProduct(callback);

        return result;
    }

    public AcceptanceProduct UpdateProductInAcceptance(AcceptanceProduct acceptanceProduct)
    {
        if (!_acceptanceRepository.IsAcceptanceExist(acceptanceProduct.AcceptanceId))
            throw new ObjectNotExistException("Acceptance", acceptanceProduct.AcceptanceId);
        if (!_productRepository.IsProductExist(acceptanceProduct.ProductId))
            throw new ObjectNotExistException("Product", acceptanceProduct.ProductId);
        if (_acceptanceRepository.IsFactCountAlreadyAdded(acceptanceProduct.AcceptanceId, acceptanceProduct.ProductId))
            throw new RepetativeActionException("Adding", "Fact Product Count");
        if (acceptanceProduct.FactProductCount < 0)
            throw new ArgumentOutOfRangeException("", "Fact Product count must be non negative");
        
        var dto = _mapper.MapAcceptanceProductToAcceptanceProductDto(acceptanceProduct);
        var callback = _acceptanceRepository.UpdateProductInAcceptance(dto);

        callback.Acceptance = _acceptanceRepository.GetAcceptanceById(acceptanceProduct.AcceptanceId);
        callback.Acceptance.FormedBy = _userRepository.GetUserById(callback.Acceptance.FormedById);
        callback.Acceptance.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.Acceptance.FormedBy.AuthorizationId);
        callback.Acceptance.FormedBy.Shop = _shopRepository.GetShopById(callback.Acceptance.FormedBy.ShopId);
        callback.Acceptance.Shop = _shopRepository.GetShopById(callback.Acceptance.ShopId);
        callback.Product = _productRepository.GetProductById(callback.ProductId);

        var result = _mapper.MapAcceptanceProductDtoToAcceptanceProduct(callback);

        return result;
    }

    public Acceptance UpdateAcceptance(Acceptance acceptance)
    {
        if (!_acceptanceRepository.IsAcceptanceExist(acceptance.Id))
            throw new ObjectNotExistException("Acceptance", acceptance.Id);
        if (!_userRepository.IsUserExist((int)acceptance.SignedById!))
            throw new ObjectNotExistException("User", (int)acceptance.SignedById!);
        if (_acceptanceRepository.IsAcceptanceSigned(acceptance.Id))
            throw new RepetativeActionException("Signed", "Acceptance");

        var dto = _mapper.MapAcceptanceToAcceptanceDto(acceptance);
        dto.FactTime = DateTime.Now;
        var callback = _acceptanceRepository.UpdateAcceptance(dto);

        callback.SignedBy = _userRepository.GetUserById((int)callback.SignedById!);
        callback.SignedBy.Authorization = _userRepository.GetAuthorizationById(callback.SignedBy.AuthorizationId);
        callback.SignedBy.Shop = _shopRepository.GetShopById(callback.SignedBy.ShopId);
        callback.FormedBy = _userRepository.GetUserById(callback.FormedById);
        callback.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.FormedBy.AuthorizationId);
        callback.FormedBy.Shop = _shopRepository.GetShopById(callback.FormedBy.ShopId);
        callback.Shop = _shopRepository.GetShopById(callback.ShopId);

        var result = _mapper.MapAcceptanceDtoToAcceptance(callback);

        return result;
    }

    public Acceptance GetAcceptanceById(int id)
    {
        if (!_acceptanceRepository.IsAcceptanceExist(id))
            throw new ObjectNotExistException("Acceptance", id);

        var callback = _acceptanceRepository.GetAcceptanceById(id);

        callback.SignedBy = _userRepository.GetUserById((int)callback.SignedById!);
        callback.SignedBy.Authorization = _userRepository.GetAuthorizationById(callback.SignedBy.AuthorizationId);
        callback.SignedBy.Shop = _shopRepository.GetShopById(callback.SignedBy.ShopId);
        callback.FormedBy = _userRepository.GetUserById(callback.FormedById);
        callback.FormedBy.Authorization = _userRepository.GetAuthorizationById(callback.FormedBy.AuthorizationId);
        callback.FormedBy.Shop = _shopRepository.GetShopById(callback.FormedBy.ShopId);
        callback.Shop = _shopRepository.GetShopById(callback.ShopId);

        var result = _mapper.MapAcceptanceDtoToAcceptance(callback);
        
        return result;
    }

    public IEnumerable<AcceptanceProduct> GetAllProductFromAcceptanceById(int id)
    {
        var callback = _acceptanceRepository.GetAllProductFromAcceptanceById(id);

        foreach (var line in callback)
        {
            line.Product = _productRepository.GetProductById(line.ProductId);
        }

        var result = _mapper.MapAcceptanceProductDtoListToAcceptanceProductList(callback);
        return result;
    }
}