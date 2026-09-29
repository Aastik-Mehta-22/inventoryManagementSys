using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryApi
{
    [ApiController]
    [Route("api/[controller]")] // Route becomes: /api/inventory
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor
        public InventoryController(AppDbContext context)
        {
            _context = context;
            
            // Ensures the SQLite database file and 'Items' table are created automatically on startup
            _context.Database.EnsureCreated();
        }

        // 1. READ ALL: GET /api/inventory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        // 2. READ ONE BY ID: GET /api/inventory/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound($"Item with ID {id} not found.");

            return Ok(item);
        }

        // 3. CREATE: POST /api/inventory
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryItem item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync(); // Writes row to SQLite

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // 4. UPDATE: PUT /api/inventory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InventoryItem updatedItem)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound($"Item with ID {id} not found.");

            item.Name = updatedItem.Name;
            item.Category = updatedItem.Category;
            item.Quantity = updatedItem.Quantity;
            item.Price = updatedItem.Price;

            await _context.SaveChangesAsync(); // Saves updates to SQLite
            return Ok(item);
        }

        // 5. DELETE: DELETE /api/inventory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound($"Item with ID {id} not found.");

            _context.Items.Remove(item);
            await _context.SaveChangesAsync(); // Deletes row from SQLite

            return Ok(new { message = $"Item with ID {id} deleted successfully." });
        }
    }
}