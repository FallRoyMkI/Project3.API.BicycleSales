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
    public OrderProduct MapOrderProductDtoToOrderProduct(OrderProductDto dto);
    public OrderProductDto MapOrderProductToOrderProductDto(OrderProduct orderProduct);
    public IEnumerable<Order> MapOrderDtoListToOrderList(IEnumerable<OrderDto> dtos);

    public Shipment MapShipmentDtoToShipment(ShipmentDto dto);
    public ShipmentDto MapShipmentToShipmentDto(Shipment orderProduct);

    public ShipmentProduct MapShipmentProductDtoToShipmentProduct(ShipmentProductDto dto);
    public ShipmentProductDto MapShipmentProductToShipmentProductDto(ShipmentProduct dto);

    public Acceptance MapAcceptanceDtoToAcceptance(AcceptanceDto dto);
    public AcceptanceDto MapAcceptanceToAcceptanceDto(Acceptance acceptance);

    public AcceptanceProduct MapAcceptanceProductDtoToAcceptanceProduct(AcceptanceProductDto dto);
    public AcceptanceProductDto MapAcceptanceProductToAcceptanceProductDto(AcceptanceProduct acceptanceProduct);

    public ShopDto MapShopToShopDto(Shop shop);
    public Shop MapShopDtoToShop(ShopDto shopDto);

    public IEnumerable<AcceptanceProduct> MapAcceptanceProductDtoListToAcceptanceProductList(
        IEnumerable<AcceptanceProductDto> dtos);
}