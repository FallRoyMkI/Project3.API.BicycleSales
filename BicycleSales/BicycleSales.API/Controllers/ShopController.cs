using AutoMapper;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.BLL;
using Microsoft.AspNetCore.Mvc;
using BicycleSales.API.Models.Shop.Request;
using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.Product.Response;

namespace BicycleSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShopManager _shopManager;

        public ShopController(IMapper mapper = null, IShopManager shopManager = null)
        {
            _mapper = mapper; //?? new Mapper();
            _shopManager = shopManager ?? new ShopManager();
        }

        [HttpPost("create-new-shop")]
        public IActionResult CreateNewShop([FromBody] ShopAddRequest shopAddRequest)
        {
            try
            {
                var shop = _mapper.Map<Shop>(shopAddRequest);
                var callback = ((ShopManager)_shopManager).CreateNewShop(shop);
                var result = _mapper.Map<ShopResponse>(callback);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("get-all-shops", Name = "GetAllShops")]
        public IActionResult GetAllShops()
        {
            try
            {
                var listShops = ((ShopManager)_shopManager).GetAllShops();
                var result = _mapper.Map<IEnumerable<ShopResponse>>(listShops);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("get-shop-{id}", Name = "GetShopById")]
        public IActionResult GetShopById([FromRoute] int id)
        {
            try 
            { 
                var shop = ((ShopManager)_shopManager).GetShopById(id);
                var result = _mapper.Map<ShopResponse>(shop);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete("delete-shop-{id}", Name = "DeleteShop")]
        public IActionResult DeleteShop(int id)
        {
            try
            {
                var callback = ((ShopManager)_shopManager).DeleteShop(id);
                var result = _mapper.Map<ShopResponse>(callback);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
