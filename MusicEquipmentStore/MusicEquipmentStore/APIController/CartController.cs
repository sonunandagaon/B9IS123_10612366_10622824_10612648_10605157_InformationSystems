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

        SqlConnection myConnection = new SqlConnection();

        public CartController(IProductService productService)
        {
            _productService = productService;
            myConnection.ConnectionString = @"Server=DESKTOP-UDLAN01\SQLEXPRESS;Database=Products;Trusted_Connection=True;TrustServerCertificate=true;";

        }

    }
}
