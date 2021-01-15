﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string CustomAttributes { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
