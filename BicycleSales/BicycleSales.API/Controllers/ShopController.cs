﻿using AutoMapper;
using BicycleSales.API.Models.Product.Response;
using BicycleSales.API.Models.Shop.Request;
using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.ShopProduct.Request;
using BicycleSales.API.Models.ShopProduct.Response;
using BicycleSales.BLL;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.Constants.CustomExceptions.Product;
using BicycleSales.Constants.CustomExceptions.Shop;
using BicycleSales.Constants.CustomExceptions.ShopProduct;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShopManager _shopManager;
        private readonly ILogger<ShopController> _logger;

        public ShopController(IMapper mapper = null, IShopManager shopManager = null, ILogger<ShopController> logger = null)
        {
            _mapper = mapper; //?? new Mapper();
            _shopManager = shopManager ?? new ShopManager();
            _logger = logger;
        }

        [HttpPost("create-new-shop")]
        public async Task<IActionResult> CreateNewShop([FromBody] ShopAddRequest shopAddRequest)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to create a shop");

                var shop = _mapper.Map<Shop>(shopAddRequest);
                var callback = await ((ShopManager)_shopManager).CreateNewShop(shop);
                var result = _mapper.Map<ShopResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the shop when creating", result);

                return Ok(result);
            }
            catch (ShopException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpGet("get-all-shops", Name = "GetAllShops")]
        public async Task<IActionResult> GetAllShops()
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request for the get of shops");

                var listShops = await ((ShopManager)_shopManager).GetAllShops();
                var result = _mapper.Map<IEnumerable<ShopResponse>>(listShops);

                _logger.Log(LogLevel.Information, "Received the shops upon request of get", result);

                return Ok(result);
            }
            catch (ShopException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpGet("get-shop-{id}", Name = "GetShopById")]
        public async Task<IActionResult> GetShopById([FromRoute] int id)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request for the get of shop");

                var shop = await ((ShopManager)_shopManager).GetShopById(id);
                var result = _mapper.Map<ShopResponse>(shop);

                _logger.Log(LogLevel.Information, "Received the shop upon request of get", result);

                return Ok(result);
            }
            catch (ShopException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpGet("get-all-products-by-{shopId}", Name = "GetAllProductsByShopId")]
        public async Task<IActionResult> GetAllProductsByShopId([FromRoute] int shopId)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request for the get of products by shopId");

                var products = await ((ShopManager)_shopManager).GetAllProductsByShopId(shopId);
                var result = _mapper.Map<IEnumerable<ShopProductResponse>>(products);

                _logger.Log(LogLevel.Information, "Received the products upon request of GetAllProductsByShopId ", result);

                return Ok(result);
            }
            catch (ShopException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
            catch (ShopProductException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpPost("add-product-in-shop", Name = "AddProductInShopAsync")]
        public async Task<IActionResult> AddProductInShopAsync([FromBody] ShopProductAddRequest shopProduct)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to add a product in shop");

                var shopProducts = _mapper.Map<ShopProduct>(shopProduct);
                var callback = await ((ShopManager)_shopManager).AddProductInShopAsync(shopProducts);
                var result = _mapper.Map<ShopProductResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the product in shop when adding", result);

                return Ok(result);
            }
            catch (ShopProductException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
            catch (ShopException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
            catch (ProductException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }
    }
}
