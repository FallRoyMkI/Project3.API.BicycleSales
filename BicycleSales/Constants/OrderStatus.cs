namespace BicycleSales.Constants;

public enum OrderStatus
{
    OrderCreated = 0,
    OrderInProgress = 1,
    OrderIsReadyToBeTaken = 2,
    OrderFinished = 3,
    OrderCancelled = 4,
    RequiredProductSupply = 5
}