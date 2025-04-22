using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Services;
using SistemaInventario.Models;

namespace SistemaInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        // Injeção de dependência do serviço
        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
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
                return NotFound(new { Message = "Produto não encontrado." });

            return Ok(product);
        }

        // POST: api/inventory
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest(new { Message = "Dados inválidos." });

            _inventoryService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // PUT: api/inventory/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProductQuantity(int id, [FromBody] int? newQuantity)
        {
            if (!newQuantity.HasValue || newQuantity < 0)
                return BadRequest(new { Message = "Quantidade inválida." });

            var updated = _inventoryService.UpdateProductQuantity(id, newQuantity.Value);
            if (!updated)
                return NotFound(new { Message = "Produto não encontrado." });

            return NoContent();
        }

        // DELETE: api/inventory/{id}
        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            var removed = _inventoryService.RemoveProduct(id);
            if (!removed)
                return NotFound(new { Message = "Produto não encontrado." });

            return NoContent();
        }

        // GET: api/inventory/category/{category}
        [HttpGet("category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            var products = _inventoryService.GetProductsByCategory(category);
            return Ok(products);
        }

        // GET: api/inventory/price-range?minPrice=10&maxPrice=100
        [HttpGet("price-range")]
        public IActionResult GetProductsByPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var products = _inventoryService.GetProductsByPriceRange(minPrice, maxPrice);
            return Ok(products);
        }

        // PUT: api/inventory/price/{id}
        [HttpPut("price/{id}")]
        public IActionResult UpdateProductPrice(int id, [FromBody] decimal? newPrice)
        {
            if (!newPrice.HasValue || newPrice <= 0)
                return BadRequest(new { Message = "Preço inválido." });

            var updated = _inventoryService.UpdateProductPrice(id, newPrice.Value);
            if (!updated)
                return NotFound(new { Message = "Produto não encontrado." });

            return NoContent();
        }

        // GET: api/inventory/total-items
        [HttpGet("total-items")]
        public IActionResult GetTotalItemsInStock()
        {
            var totalItems = _inventoryService.GetTotalItemsInStock();
            return Ok(new { TotalItems = totalItems });
        }

        // GET: api/inventory/total-value
        [HttpGet("total-value")]
        public IActionResult GetTotalInventoryValue()
        {
            var totalValue = _inventoryService.GetTotalInventoryValue();
            return Ok(new { TotalValue = totalValue });
        }
    }
}
