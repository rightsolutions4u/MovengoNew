using System;
using System.Collections.Generic;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class ShippingMethodRestriction
    {
        public int ShippingMethodId { get; set; }
        public int CountryId { get; set; }
    }
}
