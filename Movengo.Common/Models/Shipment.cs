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
        public float DimensionsL { get; set; }
        public float DimensionsW { get; set; }
        public float DimensionsH { get; set; }
        [StringLength(25)]
        public string DimensionsUnit { get; set; }
        public float Weight { get; set; }
        [StringLength(25)]
        public string WeightUnit { get; set; }
        [StringLength(25)]
        public string CargoMode { get; set; } //Sea, Air, Land
        [StringLength(100)]
        public string CargoType { get; set; }//FCL, LCL, 
        public int OriginPortAddress_Id { get; set; }
        public int DestinationPortAddress_Id { get; set; }
        [StringLength(500)]
        public string Incoterms { get; set; }
        [StringLength(200)]
        public string SHCode { get; set; }
        [StringLength(250)]
        public string ContainerType { get; set; }
        [StringLength(250)]
        public string PackageType { get; set; }
        public float Amount { get; set; }
        public float Volume { get; set; }
        [StringLength(100)]
        public string VolumeUnit { get; set; }
        [StringLength(3)]
        public string Hazardous { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DpartureDate { get; set; }
        [StringLength(2000)]
        public string SpecialInstructions { get; set; }
        public int OrderId { get; set; }
        public string TrackingNumber { get; set; }
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
        public virtual Order Order { get; set; }
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }
    }
}
