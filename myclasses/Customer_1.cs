using Movengo.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movengo.Common
{
    public class Customer_1
    {
        public Customer_1()
        {
            
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        [StringLength(10)]
        public string MobileCode { get; set; }
        [StringLength(30)]
        public string MobileNumber { get; set; }
        [StringLength(30)]
        public string EmailId { get; set; }
        public string Username { get; set; }
        public string EmailToRevalidate { get; set; }
        public string SystemName { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public Guid CustomerGuid { get; set; }
        public string AdminComment { get; set; }
        public bool IsTaxExempt { get; set; }
        //public int AffiliateId { get; set; }
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
        public string Apitoken { get; set; }
        public virtual ICollection<Shipment_1> Shipment { get; set; }
        public virtual Address_1 BillingAddress { get; set; }
        public virtual Address_1 ShippingAddress { get; set; }



    }
}
