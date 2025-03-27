using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemaInventario.Models;
using SystemaInventario.Services;

namespace SystemaInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController()
        {
            _inventoryService = new InventoryService();
        }

        // GET: api/inventory
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _inventoryService.GetAllProducts();
            return Ok(products);
        }

        // GET: api/inventory/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _inventoryService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST: api/inventory
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _inventoryService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // PUT: api/inventory/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProductQuantity(int id, [FromBody] int newQuantity)
        {
            if (!_inventoryService.UpdateProductQuantity(id, newQuantity))
                return NotFound();
            return NoContent();
        }

        // DELETE: api/inventory/{id}
        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            if (!_inventoryService.RemoveProduct(id))
                return NotFound();
            return NoContent();
        }

        [HttpGet("category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            var products = _inventoryService.GetProductsByCategory(category);
            return Ok(products);
        }

        [HttpGet("price-range")]
        public IActionResult GetProductsByPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var products = _inventoryService.GetProductsByPriceRange(minPrice, maxPrice);
            return Ok(products);
        }

        [HttpPut("price/{id}")]
        public IActionResult UpdateProductPrice(int id, [FromBody] decimal newPrice)
        {
            if (!_inventoryService.UpdateProductPrice(id, newPrice))
                return NotFound();
            return NoContent();
        }

        [HttpGet("total-items")]
        public IActionResult GetTotalItemsInStock()
        {
            var totalItems = _inventoryService.GetTotalItemsInStock();
            return Ok(new { TotalItems = totalItems });
        }

        [HttpGet("total-value")]
        public IActionResult GetTotalInventoryValue()
        {
            var totalValue = _inventoryService.GetTotalInventoryValue();
            return Ok(new { TotalValue = totalValue });
        }
    }
}
