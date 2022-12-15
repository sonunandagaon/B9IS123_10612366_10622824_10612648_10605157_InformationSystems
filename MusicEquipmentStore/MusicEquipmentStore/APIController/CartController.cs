using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MusicEquipmentStore.Models;
using MusicEquipmentStore.Services;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

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

        //POST api/<CartController>
        [HttpPost("AddToCart")]
        public void AddToCart(Cart cart)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Carts (ProductName,ProductId,ProductPrice,ProductQuantity,UserName)" +
                "Values (@ProductName,@ProductId,@ProductPrice,@ProductQuantity,@UserName)";
            sqlCmd.Connection = myConnection;
            // sqlCmd.Parameters.AddWithValue("@Id", cart.Id);
            sqlCmd.Parameters.AddWithValue("@ProductName", cart.ProductName);
            sqlCmd.Parameters.AddWithValue("@ProductId", cart.ProductId);
            sqlCmd.Parameters.AddWithValue("@ProductPrice", cart.ProductPrice);
            sqlCmd.Parameters.AddWithValue("@ProductQuantity", cart.ProductQuantity);
            sqlCmd.Parameters.AddWithValue("@UserName", cart.UserName);
            //sqlCmd.Parameters.AddWithValue("@UserAddress", cart.UserAddress);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();

           

        }

        // DELETE api/<CartController>/5
        [HttpDelete("DeleteCart/{id:int}/{username}")]
        public void Delete(int id, string username)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from Cart_table where Id= " + id + " and UserName='" + username + "'";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        [HttpPut("Update")]
        public void Update(UpdateCart cart)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            //increase functionality
            if (cart.UpdateStatus = true)
            {
                sqlCmd.CommandText = "Update Carts Set ProductQuantity='" + cart.ProductQuantity +
                    "', ProductPrice= '" + cart.ProductPrice + "'" + " where UserName ='" + cart.UserName + "' and ProductId= '" + cart.ProductId + "'";

            }
            else
            {
                if (Convert.ToInt32(cart.ProductQuantity) == 0)
                {
                    sqlCmd.CommandText = "DELETE FROM Carts WHERE ProductQuantity='" +
                        cart.ProductQuantity + "' and UserName='" + cart.UserName + "'";

                }
                else
                {
                    sqlCmd.CommandText = "Update Carts Set ProductQuantity='" + cart.ProductQuantity +
                   "', ProductPrice= '" + cart.ProductPrice + "'" + " where UserName ='" + cart.UserName + "' and ProductId= '" + cart.ProductId + "'";

                }
            }
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
    }
 }
