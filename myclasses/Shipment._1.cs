using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movengo.Common.Models
{
    
    public class Shipment_1
    {
        
        [Key]
        public int ShipmentId { get; set; }
        public int WayBillNumber { get; set; }
        [StringLength(50)]
        public string TypeOfShipment { get; set; } //Online Purchase, Cargo
        [StringLength(50)]
        public string CargoShipmentType { get; set; } //Commercial/Non-Commercial
        [StringLength(50)]
        public string Link { get; set; } //Online Purchase Link
        [StringLength(50)]
        public string Destination { get; set; } //List of all cities in the format "city, Country"
        [StringLength(100)]
        public string OnlineAddress { get; set; } 
        [StringLength(100)]
        public string Origin { get; set; } //List of all cities in the format "city, Country"
        [StringLength(100)]
        public string OriginAddress { get; set; } 
        [StringLength(100)]
        public string DestinationAddress { get; set; }
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
        [StringLength(100)]
        public string OriginPort { get; set; }
        [StringLength(100)]
        public string DestinationPort { get; set; }
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
        public int Id { get; set; }
        public virtual Customer_1 Customer { get; set; }

}
}
