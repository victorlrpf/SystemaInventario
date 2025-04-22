using MySql.Data.MySqlClient;
using SistemaInventario.Models;
using System.Data;

namespace SistemaInventario.Services
{
    public class MySqlDatabaseService
    {
        private readonly string _connectionString;

        public MySqlDatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Product> LoadProducts()
        {
            var products = new List<Product>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT Id, Name, Category, Price, Quantity FROM Products";

            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Category = reader.GetString("Category"),
                    Price = reader.GetDecimal("Price"),
                    Quantity = reader.GetInt32("Quantity")
                });
            }

            return products;
        }

        public void SaveProduct(Product product)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO Products (Name, Category, Price, Quantity) VALUES (@name, @category, @price, @quantity)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@category", product.Category);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);
            cmd.ExecuteNonQuery();

            product.Id = (int)cmd.LastInsertedId; // <- Aqui você pega o Id gerado
        }


        public void DeleteProduct(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "DELETE FROM Products WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateProduct(Product product)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "UPDATE Products SET Name = @name, Category = @category, Price = @price, Quantity = @quantity WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@category", product.Category);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@id", product.Id);
            cmd.ExecuteNonQuery();
        }
    }
}
