﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class Customer
    {
        public Customer()
        {
            //CustomerAddresses = new HashSet<CustomerAddress>();
            //CustomerCustomerRoleMappings = new HashSet<CustomerCustomerRoleMapping>();
            //Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string EmailToRevalidate { get; set; }
        public string SystemName { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public Guid CustomerGuid { get; set; }
        public string AdminComment { get; set; }
        public bool IsTaxExempt { get; set; }
        public int AffiliateId { get; set; }
        public int VendorId { get; set; }
        public bool HasShoppingCartItems { get; set; }
        public bool RequireReLogin { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? CannotLoginUntilDateUtc { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public bool IsSystemAccount { get; set; }
        public string LastIpAddress { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime LastActivityDateUtc { get; set; }
        public int RegisteredInStoreId { get; set; }
        public string Password { get; set; }
        public string Apitoken { get; set; }

        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }
        //public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        //public virtual ICollection<CustomerCustomerRoleMapping> CustomerCustomerRoleMappings { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
