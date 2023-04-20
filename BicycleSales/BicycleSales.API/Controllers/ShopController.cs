using AutoMapper;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.BLL;
using Microsoft.AspNetCore.Mvc;
using BicycleSales.API.Models.Shop.Request;
using BicycleSales.API.Models.Shop.Response;

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

        [HttpPost("create-new-acceptance")]
        public IActionResult CreateNewAcceptance([FromBody] ShopAddRequest shopAddRequest)
        {
            try
            {
                var shop = _mapper.Map<Shop>(shopAddRequest);
                var callback = _shopManager.CreateNewShop(shop);
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
