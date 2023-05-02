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

    public AcceptanceManager(IMapperBLL mapper, IAcceptanceRepository acceptanceRepository,
        IUserRepository userRepository, IShopRepository shopRepository, IProductRepository productRepository)
    {
        _mapper = mapper;
        _acceptanceRepository = acceptanceRepository;
        _userRepository = userRepository;
        _shopRepository = shopRepository;
        _productRepository = productRepository;
    }

    public async Task<Acceptance> CreateNewAcceptance(Acceptance acceptance)
    {
        if (!_userRepository.IsUserExist(acceptance.FormedById)) 
            throw new ObjectNotExistException("User", acceptance.FormedById);
        if (!_shopRepository.IsShopExist(acceptance.ShopId)) 
            throw new ObjectNotExistException("Shop", acceptance.ShopId);
        if (acceptance.PlanedTime < DateTime.UtcNow)
            throw new InvalidTimeException(acceptance.PlanedTime);

        var dto = _mapper.MapAcceptanceToAcceptanceDto(acceptance);
        var callback = _acceptanceRepository.CreateNewAcceptance(dto);

        var result = _mapper.MapAcceptanceDtoToAcceptance(callback);

        return result;
    }

    public async Task<AcceptanceProduct> AddProductToAcceptance(AcceptanceProduct acceptanceProduct)
    {
        if (!_acceptanceRepository.IsAcceptanceExist(acceptanceProduct.AcceptanceId))
            throw new ObjectNotExistException("Acceptance", acceptanceProduct.AcceptanceId);
        if (!_productRepository.IsProductExist(acceptanceProduct.ProductId))
            throw new ObjectNotExistException("Product", acceptanceProduct.ProductId);
        if (acceptanceProduct.ProductCount < 1) 
            throw new ArgumentOutOfRangeException("", "Product count must be positive");
        if (_acceptanceRepository.IsProductExistInAcceptance(acceptanceProduct.AcceptanceId, acceptanceProduct.ProductId))
            throw new RepetativeActionException("Adding", "Product");
        if (_acceptanceRepository.IsAcceptanceSigned(acceptanceProduct.AcceptanceId))
            throw new WorkWithForbiddenResourceException("Acceptance",acceptanceProduct.Id);

        var dto = _mapper.MapAcceptanceProductToAcceptanceProductDto(acceptanceProduct);
        var callback = _acceptanceRepository.AddProductToAcceptance(dto);

        var result = _mapper.MapAcceptanceProductDtoToAcceptanceProduct(callback);

        return result;
    }

    public async Task<AcceptanceProduct> UpdateProductInAcceptance(AcceptanceProduct acceptanceProduct)
    {
        if (!_acceptanceRepository.IsAcceptanceExist(acceptanceProduct.AcceptanceId))
            throw new ObjectNotExistException("Acceptance", acceptanceProduct.AcceptanceId);
        if (!_productRepository.IsProductExist(acceptanceProduct.ProductId))
            throw new ObjectNotExistException("Product", acceptanceProduct.ProductId);
        if (!_acceptanceRepository.IsProductExistInAcceptance(acceptanceProduct.AcceptanceId,acceptanceProduct.ProductId))
                throw new ObjectNotExistException("Product in Acceptance", acceptanceProduct.ProductId);

        if (_acceptanceRepository.IsFactCountAlreadyAdded(acceptanceProduct.AcceptanceId, acceptanceProduct.ProductId))
            throw new RepetativeActionException("Adding", "Fact Product Count");
        if (acceptanceProduct.FactProductCount < 0)
            throw new ArgumentOutOfRangeException("", "Fact Product count must be non negative");
        
        var dto = _mapper.MapAcceptanceProductToAcceptanceProductDto(acceptanceProduct);
        var callback = _acceptanceRepository.UpdateProductInAcceptance(dto);

        var result = _mapper.MapAcceptanceProductDtoToAcceptanceProduct(callback);

        return result;
    }

    public async Task<Acceptance> UpdateAcceptance(Acceptance acceptance)
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

        var result = _mapper.MapAcceptanceDtoToAcceptance(callback);

        return result;
    }

    public async Task<Acceptance> GetAcceptanceById(int id)
    {
        if (!_acceptanceRepository.IsAcceptanceExist(id))
            throw new ObjectNotExistException("Acceptance", id);

        var callback = _acceptanceRepository.GetAcceptanceById(id);

        var result = _mapper.MapAcceptanceDtoToAcceptance(callback);
        
        return result;
    }

    public async Task<IEnumerable<AcceptanceProduct>> GetAllProductFromAcceptanceById(int id)
    {
        var callback = _acceptanceRepository.GetAllProductFromAcceptanceById(id);

        foreach (var line in callback)
        {
            line.Product =await _productRepository.GetProductByIdAsync(line.ProductId);
        }

        var result = _mapper.MapAcceptanceProductDtoListToAcceptanceProductList(callback);
        return result;
    }
}