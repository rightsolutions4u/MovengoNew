using System;
using System.Collections.Generic;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class CustomerRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }
        public bool FreeShipping { get; set; }
        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public bool EnablePasswordLifetime { get; set; }
        public bool OverrideTaxDisplayType { get; set; }
        public int DefaultTaxDisplayTypeId { get; set; }
        public int PurchasedWithProductId { get; set; }
    }
}
