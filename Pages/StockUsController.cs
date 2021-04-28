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
    public class StockUsController : ControllerBase
    {
        private readonly ShoppingListContext _context;


        public StockUsController(ShoppingListContext context)
        {
            _context = context;
        }

        // GET: api/StockUs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockU>>> GetStockUs()
        {
            return await _context.StockU.ToListAsync();
        }

        // GET: api/StockUs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockU>> GetStockU(int id)
        {


            var stockU = await _context.StockU.FindAsync(id);

            if (stockU == null)
            {
                return NotFound();
            }

            return stockU;
        }

        [HttpGet("SUser/{userid}")]
        public async Task<ActionResult<IEnumerable<StockU>>> GetStockUser(Guid userid)
        {
            return await _context.StockU.Where(s => s.UserID == userid).ToListAsync();
        }


        // PUT: api/StockUs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockU(int id, StockU stockU)
        {
            if (id != stockU.ID)
            {
                return BadRequest();
            }

            _context.Entry(stockU).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockUExists(id))
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

        // POST: api/StockUs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StockU>> PostStockU(StockU stockU)
        {

            _context.StockU.Add(stockU);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockU", new { id = stockU.ID }, stockU);
        }


        // DELETE: api/StockUs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockU>> DeleteStockU(int id)
        {
            var stockU = await _context.StockU.FindAsync(id);
            if (stockU == null)
            {
                return NotFound();
            }

            _context.StockU.Remove(stockU);
            await _context.SaveChangesAsync();

            return stockU;
        }

        private bool StockUExists(int id)
        {
            return _context.StockU.Any(e => e.ID == id);
        }
    }
}
