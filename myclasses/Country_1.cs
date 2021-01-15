using Movengo.Common.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class Country_1
    {
        public Country_1()
        {
            //Addresses = new HashSet<Address_1>();
            //ShippingMethodRestrictions = new HashSet<ShippingMethodRestriction>();
            StateProvinces = new HashSet<StateProvince_1>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public bool AllowsBilling { get; set; }
        public bool AllowsShipping { get; set; }
        public int NumericIsoCode { get; set; }
        public bool SubjectToVat { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public bool LimitedToStores { get; set; }

        public virtual ICollection<Address_1> Addresses { get; set; }
        //public virtual ICollection<ShippingMethodRestriction> ShippingMethodRestrictions { get; set; }
        public virtual ICollection<StateProvince_1> StateProvinces { get; set; }
    }
}
