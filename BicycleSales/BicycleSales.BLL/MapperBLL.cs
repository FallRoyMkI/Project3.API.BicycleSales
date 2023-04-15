using AutoMapper;
using BicycleSales.BLL.Models;
using BicycleSales.DAL.Models;

namespace BicycleSales.BLL;

public class MapperBLL
{
    private readonly MapperConfiguration _cfg;

    public MapperBLL()
    {
        _cfg = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<AuthorizationDto, Authorization>().ReverseMap();
                
                cfg.CreateMap<UserDto, User>().ReverseMap();

                cfg.CreateMap<Product, ProductDto>().ReverseMap();
                cfg.CreateMap<ProductDto, Product>().ReverseMap();

                cfg.CreateMap<Tag, TagDto>().ReverseMap();
                cfg.CreateMap<TagDto, Tag>().ReverseMap();

                cfg.CreateMap<ProductTagDto, ProductTag>().ReverseMap();
            });
    }

    public Authorization MapAuthorizationDtoToAuthorization(AuthorizationDto dto)
    {
        return _cfg.CreateMapper().Map<Authorization>(dto);
    }
    public AuthorizationDto MapAuthorizationToAuthorizationDto(Authorization auth)
    {
        return _cfg.CreateMapper().Map<AuthorizationDto>(auth);
    }

    public User MapUserDtoToUser(UserDto dto)
    {
        return _cfg.CreateMapper().Map<User>(dto);
    }
    public UserDto MapUserToUserDto(User user)
    {
        return _cfg.CreateMapper().Map<UserDto>(user);
    }
    public ProductDto MapProductToProductDto(Product productBll)
    {
        return _cfg.CreateMapper().Map<ProductDto>(productBll);
    }
    public Product MapProductDtoToProduct(ProductDto productDto)
    {
        return _cfg.CreateMapper().Map<Product>(productDto);
    }
    public IEnumerable<Product> MapListProductDtoToListProduct(IEnumerable<ProductDto> listProductsDto)
    {
        return _cfg.CreateMapper().Map<IEnumerable<Product>>(listProductsDto);
    }

    public TagDto MapTagToTagDto(Tag tagBll)
    {
        return _cfg.CreateMapper().Map<TagDto>(tagBll);
    }
    
    public Tag MapTagDtoToTag(TagDto tagDto)
    {
        return _cfg.CreateMapper().Map<Tag>(tagDto);
    }

    public ProductTag MapProductTagDtoToProductTag(ProductTagDto productTagDto)
    {
        return _cfg.CreateMapper().Map<ProductTag>(productTagDto);
    }
    
}