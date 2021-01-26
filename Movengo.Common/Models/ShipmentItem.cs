using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class ShipmentItem
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public string Incoterms { get; set; }
        [StringLength(200)]
        public string SHCode { get; set; }
        [StringLength(250)]
        public string ContainerType { get; set; }
        [StringLength(250)]
        public string PackageType { get; set; }
        public float DimensionsL { get; set; }
        public float DimensionsW { get; set; }
        public float DimensionsH { get; set; }
        [StringLength(25)]
        public string DimensionsUnit { get; set; }
        public float Weight { get; set; }
        [StringLength(25)]
        public string WeightUnit { get; set; }
        public float Amount { get; set; }
        public float Volume { get; set; }
        [StringLength(100)]
        public string VolumeUnit { get; set; }
        [StringLength(3)]
        public string Hazardous { get; set; }
        public string Refrigerated { get; set; }
        public float Temperature { get; set; }
        [StringLength(25)]
        public string TemperatureUnit { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
