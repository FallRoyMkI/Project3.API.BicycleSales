﻿using BicycleSales.API.Models.AcceptanceProduct.Response;
using BicycleSales.API.Models.OrderProduct.Response;
using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.User.Response;
using BicycleSales.Constants;

namespace BicycleSales.API.Models.Order.Response;

public class OrderFullResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfCompilation { get; set; }
    public DateTime? DateOfCompletion { get; set; }
    public UserResponse User { get; set; }
    public ShopResponse Shop { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderProductResponse> Products { get; set; }
}