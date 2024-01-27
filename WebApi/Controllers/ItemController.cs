
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public ToDoItemController(AppDbcontext context)
        {
            _context = context;
        }

        // GET: api/ToDoItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetToDoItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/ToDoItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetToDoItemModel(int id)
        {
            var toDoItemModel = await _context.Items.FindAsync(id);

            if (toDoItemModel == null)
            {
                return NotFound();
            }

            return toDoItemModel;
        }

        // PUT: api/ToDoItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItemModel(int id, Item toDoItemModel)
        {
            if (id != toDoItemModel.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(toDoItemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoItem
        [HttpPost]
        public async Task<ActionResult<Item>> PostToDoItemModel(Item toDoItemModel)
        {
            _context.Items.Add(toDoItemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoItemModel", new { id = toDoItemModel.ItemId }, toDoItemModel);
        }

        // DELETE: api/ToDoItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItemModel(int id)
        {
            var toDoItemModel = await _context.Items.FindAsync(id);
            if (toDoItemModel == null)
            {
                return NotFound();
            }

            _context.Items.Remove(toDoItemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemModelExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}