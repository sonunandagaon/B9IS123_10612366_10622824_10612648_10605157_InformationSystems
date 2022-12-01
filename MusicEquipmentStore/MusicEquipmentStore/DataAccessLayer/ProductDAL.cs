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
        public List<Products> GetAllProducts()
        {
            List<Products> ListOfProducts = new List<Products>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllProducts", cn))
                {
                    if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListOfProducts.Add(new Products()
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
