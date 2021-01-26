using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class Shipment
    {
        //public Shipment()
        //{
        //    ShipmentItems = new HashSet<ShipmentItem>();
        //}
        [Key]
        public int Id { get; set; }
        public int WayBillNumber { get; set; }
        [StringLength(50)]
        public string TypeOfShipment { get; set; } //Online Purchase, Cargo
        [StringLength(50)]
        public string CargoShipmentType { get; set; } //Commercial/Non-Commercial
        [StringLength(50)]
        public string Link { get; set; } //Online Purchase Link
        [StringLength(500)]
        public string Commodity { get; set; }
        
        [StringLength(25)]
        public string CargoMode { get; set; } //Sea, Air, Land
        [StringLength(100)]
        public string CargoType { get; set; }//FCL, LCL, 
        public int OriginPortAddress_Id { get; set; }
        public int DestinationPortAddress_Id { get; set; }
        [StringLength(500)]
        
        public DateTime PickupDate { get; set; }
        public DateTime DpartureDate { get; set; }
        [StringLength(2000)]
        public string SpecialInstructions { get; set; }
        public decimal? TotalWeight { get; set; }
        public DateTime? ShippedDateUtc { get; set; }
        public DateTime? DeliveryDateUtc { get; set; }
        public string AdminComment { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int? DestinationAddress_Id { get; set; }
        public int? OriginAddress_Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Address DestinationAddress { get; set; }
        public virtual Address OriginAddress { get; set; }
        public virtual Address OriginPortAddress { get; set; }
        public virtual Address DestinationPortAddress { get; set; }
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }
    }
}
