using MusicEquipmentStore.Models;
using System.Data;
using System.Data.SqlClient;

namespace MusicEquipmentStore.DataAccessLayer
{
    public class ProductDAL
    {
        public String cnn = "";

        public ProductDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionString:DefaultConnection").Value;

        }
        public List<ProductTable> GetAllProducts()
        {
            List<ProductTable> ListOfProducts = new List<ProductTable>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllProducts", cn))
                {
                    if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListOfProducts.Add(new ProductTable()
                        {
                            ProductId = int.Parse(reader["ProductId"].ToString()),
                            Productname = reader["Productname"].ToString()

                        });
                    }
                }
            }
            return ListOfProducts;
        }
        public List<ProductTable> GetProductById(int ProductId)
        {
            List<ProductTable> ListOfProducts = new List<ProductTable>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetProductId", cn))
                {
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int);
                    cmd.Parameters["@ProductId"].Value = ProductId;
                    cmd.CommandType = CommandType.StoredProcedure;


                        if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListOfProducts.Add(new ProductTable()
                        {
                            ProductId = int.Parse(reader["ProductId"].ToString()),
                            Productname = reader["Productname"].ToString()

                        });
                    }
                }
            }
            return ListOfProducts;
        }
    }

}
