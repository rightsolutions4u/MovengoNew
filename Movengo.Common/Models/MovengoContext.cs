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
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerAttribute> CustomerAttributes { get; set; }
        public virtual DbSet<CustomerAttributeValue> CustomerAttributeValues { get; set; }
        public virtual DbSet<CustomerCustomerRoleMapping> CustomerCustomerRoleMappings { get; set; }
        public virtual DbSet<CustomerRole> CustomerRoles { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderNote> OrderNotes { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPictureMapping> ProductPictureMappings { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShipmentItem> ShipmentItems { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<TaxCategory> TaxCategories { get; set; }
        public virtual DbSet<TaxRate> TaxRates { get; set; }
        public virtual DbSet<TierPrice> TierPrices { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorBankDetail> VendorBankDetails { get; set; }
        public virtual DbSet<VendorNote> VendorNotes { get; set; }

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
                entity.ToTable("Address");

                //entity.HasOne(d => d.Country)
                //    .WithMany(p => p.Addresses)
                //    .HasForeignKey(d => d.CountryId)
                //    .HasConstraintName("FK_Address_CountryId_Country_Id");

                entity.HasOne(d => d.StateProvince)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StateProvinceId)
                    .HasConstraintName("FK_Address_StateProvinceId_StateProvince_Id");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);

                entity.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
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
                entity.ToTable("Customer");

                entity.Property(e => e.Apitoken)
                    .HasMaxLength(256)
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

                //entity.HasOne(d => d.BillingAddress)
                //    .WithMany(p => p.CustomerBillingAddresses)
                //    .HasForeignKey(d => d.BillingAddressId)
                //    .HasConstraintName("FK_Customer_BillingAddress_Id_Address_Id");

                //entity.HasOne(d => d.ShippingAddress)
                //    .WithMany(p => p.CustomerShippingAddresses)
                //    .HasForeignKey(d => d.ShippingAddressId)
                //    .HasConstraintName("FK_Customer_ShippingAddress_Id_Address_Id");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => new { e.AddressId, e.CustomerId });

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                //    entity.HasOne(d => d.Address)
                //        .WithMany(p => p.CustomerAddresses)
                //        .HasForeignKey(d => d.AddressId)
                //        .HasConstraintName("FK_CustomerAddresses_Address_Id_Address_Id");

                //    entity.HasOne(d => d.Customer)
                //        .WithMany(p => p.CustomerAddresses)
                //        .HasForeignKey(d => d.CustomerId)
                //        .HasConstraintName("FK_CustomerAddresses_Customer_Id_Customer_Id");
                //
            });
            modelBuilder.Entity<CustomerAttribute>(entity =>
                {
                    entity.ToTable("CustomerAttribute");

                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(400);
                });

                modelBuilder.Entity<CustomerAttributeValue>(entity =>
                {
                    entity.ToTable("CustomerAttributeValue");

                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(400);

                    entity.HasOne(d => d.CustomerAttribute)
                        .WithMany(p => p.CustomerAttributeValues)
                        .HasForeignKey(d => d.CustomerAttributeId)
                        .HasConstraintName("FK_CustomerAttributeValue_CustomerAttributeId_CustomerAttribute_Id");
                });

                modelBuilder.Entity<CustomerCustomerRoleMapping>(entity =>
                {
                    entity.HasKey(e => new { e.CustomerId, e.CustomerRoleId });

                    entity.ToTable("Customer_CustomerRole_Mapping");

                    entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                    entity.Property(e => e.CustomerRoleId).HasColumnName("CustomerRole_Id");

                //entity.HasOne(d => d.Customer)
                //    .WithMany(p => p.CustomerCustomerRoleMappings)
                //    .HasForeignKey(d => d.CustomerId)
                //    .HasConstraintName("FK_Customer_CustomerRole_Mapping_Customer_Id_Customer_Id");

                entity.HasOne(d => d.CustomerRole)
                        .WithMany(p => p.CustomerCustomerRoleMappings)
                        .HasForeignKey(d => d.CustomerRoleId)
                        .HasConstraintName("FK_Customer_CustomerRole_Mapping_CustomerRole_Id_CustomerRole_Id");
                });

                modelBuilder.Entity<CustomerRole>(entity =>
                {
                    entity.ToTable("CustomerRole");

                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(255);

                    entity.Property(e => e.SystemName).HasMaxLength(255);
                });

                modelBuilder.Entity<Order>(entity =>
                {
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

                //entity.HasOne(d => d.BillingAddress)
                //    .WithMany(p => p.OrderBillingAddresses)
                //    .HasForeignKey(d => d.BillingAddressId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Order_BillingAddressId_Address_Id");

                //entity.HasOne(d => d.Customer)
                //        .WithMany(p => p.Orders)
                //        .HasForeignKey(d => d.CustomerId)
                //        .OnDelete(DeleteBehavior.ClientSetNull)
                //        .HasConstraintName("FK_Order_CustomerId_Customer_Id");

                //entity.HasOne(d => d.PickupAddress)
                //    .WithMany(p => p.OrderPickupAddresses)
                //    .HasForeignKey(d => d.PickupAddressId)
                //    .HasConstraintName("FK_Order_PickupAddressId_Address_Id");

                //entity.HasOne(d => d.ShippingAddress)
                //    .WithMany(p => p.OrderShippingAddresses)
                //    .HasForeignKey(d => d.ShippingAddressId)
                //    .HasConstraintName("FK_Order_ShippingAddressId_Address_Id");
            });

                modelBuilder.Entity<OrderItem>(entity =>
                {
                    entity.ToTable("OrderItem");

                    entity.Property(e => e.DiscountAmountExclTax).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.DiscountAmountInclTax).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.ItemWeight).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.OriginalProductCost).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.PriceExclTax).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.PriceInclTax).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.UnitPriceExclTax).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.UnitPriceInclTax).HasColumnType("decimal(18, 4)");

                    entity.HasOne(d => d.Order)
                        .WithMany(p => p.OrderItems)
                        .HasForeignKey(d => d.OrderId)
                        .HasConstraintName("FK_OrderItem_OrderId_Order_Id");

                    entity.HasOne(d => d.Product)
                        .WithMany(p => p.OrderItems)
                        .HasForeignKey(d => d.ProductId)
                        .HasConstraintName("FK_OrderItem_ProductId_Product_Id");
                });

                modelBuilder.Entity<OrderNote>(entity =>
                {
                    entity.ToTable("OrderNote");

                    entity.Property(e => e.Note).IsRequired();

                    entity.HasOne(d => d.Order)
                        .WithMany(p => p.OrderNotes)
                        .HasForeignKey(d => d.OrderId)
                        .HasConstraintName("FK_OrderNote_OrderId_Order_Id");
                });

                modelBuilder.Entity<Picture>(entity =>
                {
                    entity.ToTable("Picture");

                    entity.Property(e => e.MimeType)
                        .IsRequired()
                        .HasMaxLength(40);

                    entity.Property(e => e.SeoFilename).HasMaxLength(300);
                });

                modelBuilder.Entity<Product>(entity =>
                {
                    entity.ToTable("Product");

                    entity.Property(e => e.AdditionalShippingCharge).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.AllowedQuantities).HasMaxLength(1000);

                    entity.Property(e => e.BasepriceAmount).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.BasepriceBaseAmount).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.Gtin).HasMaxLength(400);

                    entity.Property(e => e.Height).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.Length).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.ManufacturerPartNumber).HasMaxLength(400);

                    entity.Property(e => e.MaximumCustomerEnteredPrice).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                    entity.Property(e => e.MetaTitle).HasMaxLength(400);

                    entity.Property(e => e.MinimumCustomerEnteredPrice).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(400);

                    entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.OverriddenGiftCardAmount).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.ProductCost).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.RequiredProductIds).HasMaxLength(1000);

                    entity.Property(e => e.Sku).HasMaxLength(400);

                    entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");

                    entity.Property(e => e.Width).HasColumnType("decimal(18, 4)");
                });

                modelBuilder.Entity<ProductPictureMapping>(entity =>
                {
                    entity.ToTable("Product_Picture_Mapping");

                    entity.HasOne(d => d.Picture)
                        .WithMany(p => p.ProductPictureMappings)
                        .HasForeignKey(d => d.PictureId)
                        .HasConstraintName("FK_Product_Picture_Mapping_PictureId_Picture_Id");

                    entity.HasOne(d => d.Product)
                        .WithMany(p => p.ProductPictureMappings)
                        .HasForeignKey(d => d.ProductId)
                        .HasConstraintName("FK_Product_Picture_Mapping_ProductId_Product_Id");
                });

                modelBuilder.Entity<Shipment>(entity =>
                {
                    entity.ToTable("Shipment");

                    entity.Property(e => e.TotalWeight).HasColumnType("decimal(18, 4)");

                    
                });

                modelBuilder.Entity<ShipmentItem>(entity =>
                {
                    entity.ToTable("ShipmentItem");

                    //entity.HasOne(d => d.Shipment)
                    //    .WithMany(p => p.ShipmentItems)
                    //    .HasForeignKey(d => d.ShipmentId)
                    //    .HasConstraintName("FK_ShipmentItem_ShipmentId_Shipment_Id");
                });

                modelBuilder.Entity<StateProvince>(entity =>
                {
                    entity.ToTable("StateProvince");

                    entity.Property(e => e.Abbreviation).HasMaxLength(100);

                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(100);

                    //entity.HasOne(d => d.Country)
                    //    .WithMany(p => p.StateProvinces)
                    //    .HasForeignKey(d => d.CountryId)
                    //    .HasConstraintName("FK_StateProvince_CountryId_Country_Id");
                });

                modelBuilder.Entity<TaxCategory>(entity =>
                {
                    entity.ToTable("TaxCategory");

                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(400);
                });

                modelBuilder.Entity<TaxRate>(entity =>
                {
                    entity.ToTable("TaxRate");

                    entity.Property(e => e.Percentage).HasColumnType("decimal(18, 4)");
                });

                modelBuilder.Entity<TierPrice>(entity =>
                {
                    entity.ToTable("TierPrice");

                    entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                    entity.HasOne(d => d.CustomerRole)
                        .WithMany(p => p.TierPrices)
                        .HasForeignKey(d => d.CustomerRoleId)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TierPrice_CustomerRoleId_CustomerRole_Id");

                    entity.HasOne(d => d.Product)
                        .WithMany(p => p.TierPrices)
                        .HasForeignKey(d => d.ProductId)
                        .HasConstraintName("FK_TierPrice_ProductId_Product_Id");
                });

                modelBuilder.Entity<Vendor>(entity =>
                {
                    entity.ToTable("Vendor");

                    entity.Property(e => e.Email).HasMaxLength(400);

                    entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                    entity.Property(e => e.MetaTitle).HasMaxLength(400);

                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(400);

                    entity.Property(e => e.PageSizeOptions).HasMaxLength(200);

                    entity.Property(e => e.Password)
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnName("password");
                });

                modelBuilder.Entity<VendorBankDetail>(entity =>
                {
                    entity.ToTable("VendorBankDetail");

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

                    entity.HasOne(d => d.Vendor)
                        .WithMany(p => p.VendorBankDetails)
                        .HasForeignKey(d => d.VendorId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__VendorBan__Vendo__534D60F1");
                });

                modelBuilder.Entity<VendorNote>(entity =>
                {
                    entity.ToTable("VendorNote");

                    entity.Property(e => e.Note).IsRequired();

                    entity.HasOne(d => d.Vendor)
                        .WithMany(p => p.VendorNotes)
                        .HasForeignKey(d => d.VendorId)
                        .HasConstraintName("FK_VendorNote_VendorId_Vendor_Id");
                });

                OnModelCreatingPartial(modelBuilder);
            }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
