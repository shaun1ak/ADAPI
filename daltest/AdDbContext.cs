namespace daltest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdDbContext : DbContext
    {
        public AdDbContext()
            : base("name=AdDbContext1")
        {
        }

        public virtual DbSet<tblBillingAddress> tblBillingAddresses { get; set; }
        public virtual DbSet<tblCart> tblCarts { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCategorySortOrder> tblCategorySortOrders { get; set; }
        public virtual DbSet<tblManufacturer> tblManufacturers { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblOrderDetail> tblOrderDetails { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductMapping> tblProductMappings { get; set; }
        public virtual DbSet<tblProductType> tblProductTypes { get; set; }
        public virtual DbSet<tblShippingAddress> tblShippingAddresses { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cAddress1)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cAddress2)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cCity)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cState)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cCountry)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cPIN)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cPhone1)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cPhone2)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblBillingAddress>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblCart>()
                .Property(e => e.CartId)
                .IsUnicode(false);

            modelBuilder.Entity<tblCart>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.cCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.cName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.dModifiedDate)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .HasMany(e => e.tblProductMappings)
                .WithOptional(e => e.tblCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<tblCategorySortOrder>()
                .Property(e => e.cCategory)
                .IsUnicode(false);

            modelBuilder.Entity<tblManufacturer>()
                .Property(e => e.cCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblManufacturer>()
                .Property(e => e.cName)
                .IsUnicode(false);

            modelBuilder.Entity<tblManufacturer>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tblManufacturer>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblManufacturer>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblManufacturer>()
                .Property(e => e.dModifiedDate)
                .IsUnicode(false);

            modelBuilder.Entity<tblManufacturer>()
                .HasMany(e => e.tblProductMappings)
                .WithOptional(e => e.tblManufacturer)
                .HasForeignKey(e => e.ManufacturerId);

            modelBuilder.Entity<tblOrder>()
                .Property(e => e.RefCartNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblOrder>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblOrder>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblOrder>()
                .HasMany(e => e.tblOrderDetails)
                .WithRequired(e => e.tblOrder)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblOrderDetail>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblOrderDetail>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cProdId)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cName)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cDescription1)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cDescription2)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cResolution)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cAccuracy)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cPageNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cMake)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.dCostPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.dQuotePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.dNetPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.dDiscount1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.dDiscount2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.dMinStock)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cDigitalAnalog)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.dModifiedDate)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.cCategory)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblCarts)
                .WithRequired(e => e.tblProduct)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProduct>()
                .HasMany(e => e.tblProductMappings)
                .WithOptional(e => e.tblProduct)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<tblProductMapping>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductMapping>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductMapping>()
                .Property(e => e.dModifiedDate)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductType>()
                .Property(e => e.cCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductType>()
                .Property(e => e.cName)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductType>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductType>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductType>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductType>()
                .Property(e => e.dModifiedDate)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductType>()
                .HasMany(e => e.tblProductMappings)
                .WithOptional(e => e.tblProductType)
                .HasForeignKey(e => e.ProductTypeId);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cAddress1)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cAddress2)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cCity)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cState)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cCountry)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cPIN)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cPhone1)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cPhone2)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblShippingAddress>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cUserId)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cEmailId)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cPassword)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cTitle)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cMiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cLastName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.cModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblBillingAddresses)
                .WithRequired(e => e.tblUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblOrders)
                .WithRequired(e => e.tblUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblShippingAddresses)
                .WithRequired(e => e.tblUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
