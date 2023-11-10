using Microsoft.Data.SqlClient;
using MVC04.Models;
using System.Data;

namespace MVC04.Repository
{
    public class ProductRepository
    {
        private string connectionString = "Data Source=DESKTOP-GOAKFLS\\SQLEXPRESS;Initial Catalog=Ltwnc;Integrated Security=True; TrustServerCertificate=True";


        public bool AddProduct(string productName, string imageURL, decimal productPrice, string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE ProductName = @ProductName", connection))
                {
                    connection.Open();
                    checkCommand.Parameters.AddWithValue("@ProductName", productName);
                    int existingProductCount = (int)checkCommand.ExecuteScalar();

                    if (existingProductCount == 0)
                    {
                        using (SqlCommand command = new SqlCommand("AddProduct", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ProductName", productName);
                            command.Parameters.AddWithValue("@ImageURL", imageURL);
                            command.Parameters.AddWithValue("@ProductPrice", productPrice);
                            command.Parameters.AddWithValue("@Description", description);

                            command.ExecuteNonQuery();
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }


        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["ProductName"].ToString(),
                                ImageURL = reader["ImageURL"].ToString(),
                                ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
                                Description = reader["Description"].ToString()
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
