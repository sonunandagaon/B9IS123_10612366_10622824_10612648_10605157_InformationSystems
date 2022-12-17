using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MusicEquipmentStore.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace MusicEquipmentStore.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        SqlConnection myConnection = new SqlConnection();

        public CartController()
        {
            myConnection.ConnectionString = @"Server=DESKTOP-DGLDM4B\MSSQLSERVER2019;Database=MusicEquipmentStore;Trusted_Connection=True;TrustServerCertificate=true;";

        }

        // GET: api/<CartController> 
        [HttpGet("GetCartItems/{username}")]
        public List<Cart> GetCartItems(string username)
        {
            
            SqlDataReader reader = null;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Carts where UserName= '" + username + "'";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Cart> cart = new List<Cart>();
            Cart newcart = new Cart();
            while (reader.Read())
            {
                cart.Add(new Cart()
                {
                    Id = reader.GetInt32("Id"),
                    ProductName = reader.GetString("ProductName"),
                    ProductId = reader.GetInt32("ProductId"),
                    ProductPrice = reader.GetString("ProductPrice"),
                    ProductQuantity = reader.GetString("ProductQuantity"),
                    UserName = reader.GetString("UserName"),
                });
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
             myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();

        }

        // DELETE api/<CartController>/5
        [HttpDelete("DeleteCart/{username}")]
        public void Delete(string username)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from Carts where UserName='" + username + "'";
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
            if (cart.UpdateStatus == true)
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
