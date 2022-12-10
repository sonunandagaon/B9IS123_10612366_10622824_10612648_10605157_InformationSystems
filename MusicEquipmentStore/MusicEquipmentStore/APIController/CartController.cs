using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicEquipmentStore.Models;
using MusicEquipmentStore.Services;
using System.Data;
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

        // GET: api/<CartController> 
        [HttpGet("GetCartItems")]
        public Cart GetCartItems()
        {

            SqlDataReader reader = null;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            int id = 1;
            sqlCmd.CommandText = "Select * from Cart_table where Id=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Cart cart = null;
            while (reader.Read())
            {
                cart = new Cart();
                cart.ProductName = reader.GetValue(1).ToString();
                cart.ProductId = Convert.ToInt32(reader.GetValue(2));
                cart.ProductPrice = reader.GetValue(3).ToString();
                cart.ProductQuantity = reader.GetValue(4).ToString();
                cart.UserName = reader.GetValue(5).ToString();
                cart.UserAddress = reader.GetValue(6).ToString();
            }

            return cart; 
            
            myConnection.Close();

        }

        }
    }
