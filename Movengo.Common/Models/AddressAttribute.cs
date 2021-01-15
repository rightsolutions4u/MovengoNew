﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class AddressAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }
    }
}