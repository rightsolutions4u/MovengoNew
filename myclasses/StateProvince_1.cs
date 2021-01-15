using Movengo.Common.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class StateProvince_1
    {
        //public StateProvince_1()
        //{
        //    Addresses = new HashSet<Address_1>();
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int CountryId { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public virtual Country_1 Country { get; set; }
        public virtual ICollection<Address_1> Address { get; set; }
    }
}
