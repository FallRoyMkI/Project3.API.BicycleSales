namespace BicycleSales.DAL.Constant;

public enum OrderStatus
{
    OrderCreated,
    OrderInProgress,
    OrderIsReadyToBeTaken,
    OrderFinished,
    OrderCancelled,
    RequiredProductSupply
}