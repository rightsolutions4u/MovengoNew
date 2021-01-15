using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Movengo.Common.Models
{
    public partial class MovengoContext : DbContext
    {
        public MovengoContext()
        {
        }

        public MovengoContext(DbContextOptions<MovengoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressAttribute> AddressAttributes { get; set; }
        public virtual DbSet<AddressAttributeValue> AddressAttributeValues { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerAttribute> CustomerAttributes { get; set; }
        public virtual DbSet<CustomerAttributeValue> CustomerAttributeValues { get; set; }
        public virtual DbSet<CustomerCustomerRoleMapping> CustomerCustomerRoleMappings { get; set; }
        public virtual DbSet<CustomerPassword> CustomerPasswords { get; set; }
        public virtual DbSet<CustomerRole> CustomerRoles { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderNote> OrderNotes { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShipmentItem> ShipmentItems { get; set; }
        public virtual DbSet<ShippingByWeightByTotalRecord> ShippingByWeightByTotalRecords { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }
        public virtual DbSet<ShippingMethodRestriction> ShippingMethodRestrictions { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<TaxCategory> TaxCategories { get; set; }
        public virtual DbSet<TaxRate> TaxRates { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorBankDetail> VendorBankDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TG871HS;Database=Movengo;user id= sa ; password = Aug31999_1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Address");
            });

            modelBuilder.Entity<AddressAttribute>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AddressAttribute");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<AddressAttributeValue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AddressAttributeValue");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);

                entity.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Currency");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CustomFormatting).HasMaxLength(50);

                entity.Property(e => e.DisplayLocale).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Customer");

                entity.Property(e => e.Apitoken)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("APIToken");

                entity.Property(e => e.BillingAddressId).HasColumnName("BillingAddress_Id");

                entity.Property(e => e.Email).HasMaxLength(1000);

                entity.Property(e => e.EmailToRevalidate).HasMaxLength(1000);

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAddressId).HasColumnName("ShippingAddress_Id");

                entity.Property(e => e.SystemName).HasMaxLength(400);

                entity.Property(e => e.Username).HasMaxLength(1000);
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            });

            modelBuilder.Entity<CustomerAttribute>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomerAttribute");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<CustomerAttributeValue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomerAttributeValue");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<CustomerCustomerRoleMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Customer_CustomerRole_Mapping");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CustomerRoleId).HasColumnName("CustomerRole_Id");
            });

            modelBuilder.Entity<CustomerPassword>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomerPassword");
            });

            modelBuilder.Entity<CustomerRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomerRole");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SystemName).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order");

                entity.Property(e => e.CurrencyRate).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CustomOrderNumber).IsRequired();

                entity.Property(e => e.OrderDiscount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OrderShippingExclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OrderShippingInclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OrderSubTotalDiscountExclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OrderSubTotalDiscountInclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OrderSubtotalExclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OrderSubtotalInclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OrderTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PaymentMethodAdditionalFeeExclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PaymentMethodAdditionalFeeInclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.RefundedAmount).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderItem");

                entity.Property(e => e.AirWaybilNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountAmountExclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DiscountAmountInclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Eta).HasColumnName("ETA");

                entity.Property(e => e.InvoiceUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ItemWeight).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OriginalProductCost).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PriceExclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PriceInclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.RejectedReason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ShipmentDate).HasColumnType("datetime");

                entity.Property(e => e.UnitPriceExclTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UnitPriceInclTax).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<OrderNote>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderNote");

                entity.Property(e => e.Note).IsRequired();
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Picture");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.SeoFilename).HasMaxLength(300);
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Shipment");

                entity.Property(e => e.TotalWeight).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<ShipmentItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ShipmentItem");
            });

            modelBuilder.Entity<ShippingByWeightByTotalRecord>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ShippingByWeightByTotalRecord");

                entity.Property(e => e.AdditionalFixedCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LowerWeightLimit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderSubtotalFrom).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderSubtotalTo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PercentageRateOfSubtotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RatePerWeightUnit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightFrom).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightTo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Zip).HasMaxLength(400);
            });

            modelBuilder.Entity<ShippingMethod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ShippingMethod");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<ShippingMethodRestriction>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.ShippingMethodId).HasColumnName("ShippingMethod_Id");
            });

            modelBuilder.Entity<StateProvince>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StateProvince");

                entity.Property(e => e.Abbreviation).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TaxCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TaxCategory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<TaxRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TaxRate");

                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Vendor");

                entity.Property(e => e.Email).HasMaxLength(400);

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PageSizeOptions).HasMaxLength(200);

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<VendorBankDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AccHolderName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SwiftCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
