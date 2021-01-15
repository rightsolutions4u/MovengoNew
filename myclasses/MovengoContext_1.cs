using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace Movengo.Common.Models
{
    public partial class MovengoContext_1 : DbContext
    {
        public MovengoContext_1()
        {
        }

        public MovengoContext_1(DbContextOptions<MovengoContext_1> dbContextOptions) : base(dbContextOptions)
        {
        }
        public virtual DbSet<Customer_1> Customer { get; set; }
        public virtual DbSet<Shipment_1> Shipment { get; set; }
        public virtual DbSet<Address_1> Address { get; set; }
        public virtual DbSet<Load> Load { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_1>(entity =>
            {
                //entity.ToTable("Customer");

                entity.HasIndex(e => e.Id, "IX_Customer_Id");

                entity.HasIndex(e => e.EmailId, "IX_Customer_EmailId");

            });
            modelBuilder.Entity<Shipment_1>(entity =>
            {
                //entity.ToTable("Shipment");
                entity.HasIndex(e => e.Id, "IX_Shipment_Id");
                entity.HasIndex(e => e.ShipmentId, "IX_Shipment_ShipmentId");
                entity.HasIndex(e => e.WayBillNumber, "IX_Shipment_WayBillNumber");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Shipment)
                    .HasForeignKey(d => d.Id);
                //.HasConstraintName("FK_Shipment_UserId");

            });
        }
    }
}
