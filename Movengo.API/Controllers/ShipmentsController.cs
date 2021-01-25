using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movengo.Common.Models;
using Microsoft.AspNetCore.Cors;

namespace Movengo.API.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly MovengoContext _context;

        public ShipmentsController(MovengoContext context)
        {
            _context = context;
        }

        // GET: api/Shipments
        [HttpGet("GetShipments")]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            return await _context.Shipments.ToListAsync();
        }
        

        // GET: api/Shipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(int id)
        {
            var Shipment = await _context.Shipments.FindAsync(id);

            if (Shipment == null)
            {
                return NotFound();
            }

            return Shipment;
        }

        // PUT: api/Shipments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipment(int id, Shipment Shipment)
        {
            if (id != Shipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(Shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentExists(id))
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

        // POST: api/Shipments
        
        [HttpPost("PostShipment")]
        public async Task<ActionResult<Shipment>> PostShipment(Shipment Shipment)
        {
            _context.Shipments.Add(Shipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipment", new { id = Shipment.Id }, Shipment);
        }

        // DELETE: api/Shipments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shipment>> DeleteShipment(int id)
        {
            var Shipment = await _context.Shipments.FindAsync(id);
            if (Shipment == null)
            {
                return NotFound();
            }

            _context.Shipments.Remove(Shipment);
            await _context.SaveChangesAsync();

            return Shipment;
        }

        private bool ShipmentExists(int id)
        {
            return _context.Shipments.Any(e => e.Id == id);
        }
    }
}
