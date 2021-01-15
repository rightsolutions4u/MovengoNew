using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movengo.Common.Models
{
    class InlandTransportation
    {
        public int ShipmentId { get; set; }
        [StringLength(3)]
        public string Origin { get; set; }
        [StringLength(3)]
        public string Destination { get; set; }
        [StringLength(3)]
        public string Both { get; set; }
        [StringLength(200)]
        public string OriginPickupAddress { get; set; }
        [StringLength(200)]
        public string OriginDeliveryAddress { get; set; }
        [StringLength(200)]
        public string DestinationPickupAddress { get; set; }
        [StringLength(200)]
        public string DestinationDeliveryAddress { get; set; }

    }
}
