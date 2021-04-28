using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Pages
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ShoppingListContext _context;

        public GroupsController(ShoppingListContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groups>>> GetGroups()
        {

            return await _context.Groups.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groups>> GetGroups(Guid id)
        {
            var groups = await _context.Groups.FindAsync(id);

            if (groups == null)
            {
                return NotFound();
            }

            return groups;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(Guid id, Groups groups)
        {
            if (id != groups.Id)
            {
                return BadRequest();
            }

            _context.Entry(groups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Groups>> PostProducts(Groups groups)
        {
            _context.Groups.Add(groups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = groups.Id }, groups);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Groups>> DeleteProducts(Guid id)
        {
            var groups = await _context.Groups.FindAsync(id);
            if (groups == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(groups);
            await _context.SaveChangesAsync();

            return groups;
        }

        private bool GroupsExists(Guid id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}

