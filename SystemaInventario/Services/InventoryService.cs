using System.Collections.Generic;
using System.Linq;
using SystemaInventario.Models;

namespace SistemaInventario.Services
{
    public class InventoryService
    {
        private readonly JsonDatabaseService _db;

        public InventoryService()
        {
            _db = new JsonDatabaseService();
        }

        public List<Product> GetAllProducts() => _db.LoadProducts();

        public Product GetProductById(int id) =>
            _db.LoadProducts().FirstOrDefault(p => p.Id == id);

        public void AddProduct(Product product)
        {
            var products = _db.LoadProducts();

            // 🔹 Gerando ID automaticamente
            int newId = products.Any() ? products.Max(p => p.Id) + 1 : 1;
            product.Id = newId;

            products.Add(product);
            _db.SaveProducts(products); // Salva no JSON
        }

        public bool RemoveProduct(int id)
        {
            var products = _db.LoadProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                _db.SaveProducts(products);
                return true;
            }
            return false;
        }

        public bool UpdateProductQuantity(int id, int newQuantity)
        {
            var products = _db.LoadProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Quantity = newQuantity;
                _db.SaveProducts(products);
                return true;
            }
            return false;
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _db.LoadProducts()
                .Where(p => p.Category.ToLower() == category.ToLower())
                .ToList();
        }

        public List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _db.LoadProducts()
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
        }

        public bool UpdateProductPrice(int id, decimal newPrice)
        {
            var products = _db.LoadProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Price = newPrice;
                _db.SaveProducts(products);
                return true;
            }
            return false;
        }

        public int GetTotalItemsInStock()
        {
            return _db.LoadProducts().Sum(p => p.Quantity);
        }

        public decimal GetTotalInventoryValue()
        {
            return _db.LoadProducts().Sum(p => p.Price * p.Quantity);
        }
    }
}
