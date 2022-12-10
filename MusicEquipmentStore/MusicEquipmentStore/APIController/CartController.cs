using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicEquipmentStore.Services;
using System.Data.SqlClient;

namespace MusicEquipmentStore.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;

        }

    }
}
