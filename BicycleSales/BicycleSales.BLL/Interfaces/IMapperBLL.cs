using BicycleSales.BLL.Models;
using BicycleSales.DAL.Models;

namespace BicycleSales.BLL.Interfaces;

public interface IMapperBLL
{

    public Authorization MapAuthorizationDtoToAuthorization(AuthorizationDto dto);

    public AuthorizationDto MapAuthorizationToAuthorizationDto(Authorization auth);

    public User MapUserDtoToUser(UserDto dto);

    public UserDto MapUserToUserDto(User user);

    public Order MapOrderDtoToOrder(OrderDto dto);

    public OrderDto MapOrderToOrderDto(Order order);

    public IEnumerable<Order> MapOrderDtoListToOrderList(IEnumerable<OrderDto> dtos);

    public OrderProduct MapOrderProductDtoToOrderProduct(OrderProductDto dto);

    public OrderProductDto MapOrderProductToOrderProductDto(OrderProduct orderProduct);

    public Shipment MapShipmentDtoToShipment(ShipmentDto dto);

    public ShipmentDto MapShipmentToShipmentDto(Shipment shipment);

    public ShipmentProduct MapShipmentProductDtoToShipmentProduct(ShipmentProductDto dto);

    public ShipmentProductDto MapShipmentProductToShipmentProductDto(ShipmentProduct shipmentProduct);

    public Acceptance MapAcceptanceDtoToAcceptance(AcceptanceDto dto);

    public AcceptanceDto MapAcceptanceToAcceptanceDto(Acceptance acceptance);

    public AcceptanceProduct MapAcceptanceProductDtoToAcceptanceProduct(AcceptanceProductDto dto);

    public AcceptanceProductDto MapAcceptanceProductToAcceptanceProductDto(AcceptanceProduct acceptanceProduct);

    public ProductDto MapProductToProductDto(Product productBll);

    public Product MapProductDtoToProduct(ProductDto productDto);

    public IEnumerable<Product> MapListProductDtoToListProduct(IEnumerable<ProductDto> listProductsDto);

    public TagDto MapTagToTagDto(Tag tagBll);

    public Tag MapTagDtoToTag(TagDto tagDto);

    public ProductTag MapProductTagDtoToProductTag(ProductTagDto productTagDto);

    public ShopDto MapShopToShopDto(Shop shop);

    public Shop MapShopDtoToShop(ShopDto shopDto);

    public IEnumerable<ShopProduct> MapListShopProductDtoToListShopProduct(IEnumerable<ShopProductDto> shopProductsDto);

    public IEnumerable<AcceptanceProduct> MapAcceptanceProductDtoListToAcceptanceProductList(
        IEnumerable<AcceptanceProductDto> dtos);
    public IEnumerable<ShipmentProduct> MapShipmentProductDtoListToShipmentProductList(
        IEnumerable<ShipmentProductDto> dtos);
    public IEnumerable<Tag> MapListTagDtoToListTag(IEnumerable<TagDto> tagsDto);


    public ShopProduct MapShopProductDtoToShopProduct(ShopProductDto shopProductDto);
    public ShopProductDto MapShopProductToShopProductDto(ShopProduct shopProductDto);
    public IEnumerable<Shop> MapListShopDtoToListShop(IEnumerable<ShopDto> shopsDto);

    

}