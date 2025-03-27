using SystemaInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace SystemaInventario.Services
{
    public class InventoryService
    {
        // Lista que vai armazenar os produtos em memória
        private readonly List<Product> _inventory;

        public InventoryService()
        {
            _inventory = new List<Product>();
        }

        public List<Product> GetAllProducts()
        {
            return _inventory;
        }

        public Product GetProductById(int id)
        {
            return _inventory.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            _inventory.Add(product);
        }

        public bool RemoveProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _inventory.Remove(product);
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
                return true;
            }
            return false;
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _inventory.Where(p => p.Category.ToLower() == category.ToLower()).ToList();
        }

        public List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _inventory.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }

        public bool UpdateProductPrice(int id, decimal newPrice)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                product.Price = newPrice;
                return true;
            }
            return false;
        }

        public int GetTotalItemsInStock()
        {
            return _inventory.Sum(p => p.Quantity);
        }

        public decimal GetTotalInventoryValue()
        {
            return _inventory.Sum(p => p.Price * p.Quantity);
        }

    }
}
