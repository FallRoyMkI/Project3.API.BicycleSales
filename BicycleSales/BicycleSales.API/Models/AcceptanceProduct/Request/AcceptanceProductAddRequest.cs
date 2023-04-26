namespace BicycleSales.API.Models.AcceptanceProduct.Request;

public class AcceptanceProductAddRequest
{
    public int AcceptanceId { get; set; }
    public int ProductId { get; set; }
    public int ProductCount { get; set; }
}