using System;
using System.Collections.Generic;
using System.Text;

namespace Movengo.Common.Models
{
    public class ShipmentModel
    {
        public Address Address_origin { get; set; }
        public Address Address_dest { get; set; }
        public Shipment Shipment { get; set; }
    }
}
