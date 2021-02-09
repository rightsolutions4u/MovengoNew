using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movengo.Common.Models;
using Microsoft.AspNetCore.Cors;
using System;

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
        
        [HttpPost("PostShipment1")]
        public async Task<ActionResult<Shipment>> PostShipment1(Shipment Shipment)
        {
            _context.Shipments.Add(Shipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipment", new { id = Shipment.Id }, Shipment);
        }

        [HttpPost("PostShipment")]
        public async Task<ActionResult<Shipment>> PostShipment(ShipmentModel shipmentmodel)
        
        {
            var s = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(shipmentmodel.ToString());
            Address address_origin = new Address
            {
                Address1 = s.StreetAddress1,
                Address2 = s.StreetAddress2,
                City = s.City,
                CreatedOnUtc = DateTime.UtcNow,
                ZipPostalCode = s.ZipPostalCode,
                CountryId = s.CountryId,
            };
            _context.Addresses.Add(address_origin);
            await _context.SaveChangesAsync();
            Address address_dest = new Address
            {
                Address1 = s.StreetAddress1_dest,
                Address2 = s.StreetAddress2_dest,
                City = s.City_dest,
                CreatedOnUtc = DateTime.UtcNow,
                ZipPostalCode = s.ZipPostalCode_dest,
                CountryId = s.CountryId_dest,
            };
            _context.Addresses.Add(address_dest);
            await _context.SaveChangesAsync();

            Shipment shipment = new Shipment
            {
                TypeOfShipment = s.TypeOfShipment,
                CargoShipmentType = s.CargoShipmentType,
                OriginAddress_Id = address_origin.Id,
                DestinationAddress_Id = address_dest.Id
            };
            _context.Shipments.Add(shipment);
             await _context.SaveChangesAsync();
            return await PostShipmentJson(shipment.Id);
        }


        private async Task<ActionResult<Shipment>> PostShipmentJson(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);

            if (shipment == null)
            {
                return NotFound();
            }

            return shipment;
        }

        [HttpPost("InsertShipmentItems")]
        public async Task<ActionResult<ShipmentItem>> InsertShipmentItems(List<ShipmentItem> shipmentItem)
         //public JsonResult  InsertShipmentItems(List<ShipmentItem> shipmentItem)
        {
            int shipitemId = 0;
            int i = 0;
            //Loop and insert records.
            foreach (ShipmentItem shipitem in shipmentItem)
             {
                //i = i + 1;
                ShipmentItem shipmentitem = new ShipmentItem
                {
                    Id = shipitem.Id,
                    Commodity = shipitem.Commodity,
                    DimensionsL = shipitem.DimensionsL,
                    DimensionsH = shipitem.DimensionsH,
                    DimensionsW = shipitem.DimensionsW,
                    DimensionsUnit = shipitem.DimensionsUnit,
                    Weight = shipitem.Weight,
                    WeightUnit = shipitem.WeightUnit
                };

                _context.ShipmentItems.Add(shipmentitem);
                await _context.SaveChangesAsync();
                
                shipitemId = shipmentitem.ShipmentId;
            }
            //return Json(i);
            return await PostShipmentItemJson(shipitemId);
            }

        private async Task<ActionResult<ShipmentItem>> PostShipmentItemJson(int id)
        {
            var shipmentitem = await _context.ShipmentItems.FindAsync(id);

            if (shipmentitem == null)
            {
                return NotFound();
            }

            return shipmentitem;
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
