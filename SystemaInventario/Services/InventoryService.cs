using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Models;

namespace SistemaInventario.Services
{
    public class InventoryService
    {
        private readonly MySqlDatabaseService _db;

        public InventoryService(MySqlDatabaseService db)
        {
            _db = db;
        }

        public List<Product> GetAllProducts() => _db.LoadProducts();

        public Product GetProductById(int id) =>
            _db.LoadProducts().FirstOrDefault(p => p.Id == id);

        public void AddProduct(Product product)
        {
            _db.SaveProduct(product);
        }

        public bool RemoveProduct(int id)
        {
            var existing = GetProductById(id);
            if (existing != null)
            {
                _db.DeleteProduct(id);
                return true;
            }
            return false;
        }

        public bool UpdateProductQuantity(int id, int newQuantity)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                product.Quantity = newQuantity;
                _db.UpdateProduct(product);
                return true;
            }
            return false;
        }

        public bool UpdateProductPrice(int id, decimal newPrice)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                product.Price = newPrice;
                _db.UpdateProduct(product);
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
