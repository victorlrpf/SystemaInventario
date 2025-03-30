using System.Text.Json;
using SystemaInventario.Models;

namespace SistemaInventario.Services
{
    public class JsonDatabaseService
    {
        private readonly string _filePath = "database.json";

        public List<Product> LoadProducts()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "{ \"products\": [] }");
            }

            var json = File.ReadAllText(_filePath);
            var data = JsonSerializer.Deserialize<Dictionary<string, List<Product>>>(json);
            return data?["products"] ?? new List<Product>();
        }

        public void SaveProducts(List<Product> products)
        {
            var data = new Dictionary<string, List<Product>> { { "products", products } };
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
