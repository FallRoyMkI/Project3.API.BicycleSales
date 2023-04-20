using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL.Models;
using AutoMapper;

namespace BicycleSales.BLL;

public class MapperBLL : IMapperBLL
{
    private readonly MapperConfiguration _cfg;

    public MapperBLL()
    {
        _cfg = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Authorization,AuthorizationDto >().ReverseMap();

                cfg.CreateMap<User, UserDto>().ReverseMap();

                cfg.CreateMap<Order,OrderDto>().ReverseMap();

                cfg.CreateMap<OrderProduct, OrderProductDto>().ReverseMap();

                cfg.CreateMap<Shipment,ShipmentDto>().ReverseMap();

                cfg.CreateMap<ShipmentProduct,ShipmentProductDto>().ReverseMap();

                cfg.CreateMap<Acceptance,AcceptanceDto>().ReverseMap();

                cfg.CreateMap<AcceptanceProduct,AcceptanceDto>().ReverseMap();

                cfg.CreateMap<Product, ProductDto>().ReverseMap();

                cfg.CreateMap<Tag, TagDto>().ReverseMap();

                cfg.CreateMap<ProductTagDto, ProductTag>().ReverseMap();

                cfg.CreateMap<Shop, ShopDto>().ReverseMap(); 

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

    public Order MapOrderDtoToOrder(OrderDto dto)
    {
        return _cfg.CreateMapper().Map<Order>(dto);
    }
    public OrderDto MapOrderToOrderDto(Order order)
    {
        return _cfg.CreateMapper().Map<OrderDto>(order);
    }

    public IEnumerable<Order> MapOrderDtoListToOrderList(IEnumerable<OrderDto> dtos)
    {
        return _cfg.CreateMapper().Map<IEnumerable<Order>>(dtos);
    }

    public OrderProduct MapOrderProductDtoToOrderProduct(OrderProductDto dto)
    {
        return _cfg.CreateMapper().Map<OrderProduct>(dto);
    }
    public OrderProductDto MapOrderProductToOrderProductDto(OrderProduct orderProduct)
    {
        return _cfg.CreateMapper().Map<OrderProductDto>(orderProduct);
    }

    public Shipment MapShipmentDtoToShipment(ShipmentDto dto)
    {
        return _cfg.CreateMapper().Map<Shipment>(dto);
    }
    public ShipmentDto MapShipmentToShipmentDto(Shipment shipment)
    {
        return _cfg.CreateMapper().Map<ShipmentDto>(shipment);
    }

    public ShipmentProduct MapShipmentProductDtoToShipmentProduct(ShipmentProductDto dto)
    {
        return _cfg.CreateMapper().Map<ShipmentProduct>(dto);
    }
    public ShipmentProductDto MapShipmentProductToShipmentProductDto(ShipmentProduct shipmentProduct)
    {
        return _cfg.CreateMapper().Map<ShipmentProductDto>(shipmentProduct);
    }

    public Acceptance MapAcceptanceDtoToAcceptance(AcceptanceDto dto)
    {
        return _cfg.CreateMapper().Map<Acceptance>(dto);
    }
    public AcceptanceDto MapAcceptanceToAcceptanceDto(Acceptance acceptance)
    {
        return _cfg.CreateMapper().Map<AcceptanceDto>(acceptance);
    }

    public AcceptanceProduct MapAcceptanceProductDtoToAcceptanceProduct(AcceptanceProductDto dto)
    {
        return _cfg.CreateMapper().Map<AcceptanceProduct>(dto);
    }
    public AcceptanceProductDto MapAcceptanceProductToAcceptanceProductDto(AcceptanceProduct acceptanceProduct)
    {
        return _cfg.CreateMapper().Map<AcceptanceProductDto>(acceptanceProduct);
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
    public ShopDto MapShopToShopDto(Shop shop)
    {
        return _cfg.CreateMapper().Map<ShopDto>(shop);
    }
    public Shop MapShopDtoToShop(ShopDto shopDto)
    {
        return _cfg.CreateMapper().Map<Shop>(shopDto);
    }
}