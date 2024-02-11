using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleOrderProduct> SaleOrderProducts { get; set; }
        public DbSet<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ManageProduct> ManageProducts { get; set; }
        public DbSet<ManageCategory> ManageCategories { get; set; }
        public DbSet<ManageSupplier> ManageSuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Store)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.StoreId);

            modelBuilder.Entity<SaleOrder>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.SaleOrders)
                .HasForeignKey(s => s.EmployeeId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.PurchaseOrders)
                .HasForeignKey(p => p.EmployeeId);
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<SaleOrderProduct>()
                .HasKey(sop => new { sop.SaleOrderId , sop.ProductId });
            modelBuilder.Entity<SaleOrderProduct>()
                .HasOne(sop => sop.SaleOrder)
                .WithMany(so => so.SaleOrderProducts)
                .HasForeignKey(sop => sop.SaleOrderId);
            modelBuilder.Entity<SaleOrderProduct>()
                .HasOne(sop => sop.Product)
                .WithMany(p => p.SaleOrderProducts)
                .HasForeignKey(sop => sop.ProductId);

            modelBuilder.Entity<PurchaseOrderProduct>()
                .HasKey(pop => new { pop.PurchaseOrderId, pop.ProductId });
            modelBuilder.Entity<PurchaseOrderProduct>()
                .HasOne(pop => pop.PurchaseOrder)
                .WithMany(po => po.PurchaseOrderProducts)
                .HasForeignKey(pop => pop.PurchaseOrderId);
            modelBuilder.Entity<PurchaseOrderProduct>()
                .HasOne(pop => pop.Product)
                .WithMany(p => p.PurchaseOrderProducts)
                .HasForeignKey(pop => pop.ProductId);

            modelBuilder.Entity<Inventory>()
                .HasKey(I => new { I.ProductId, I.StoreId });
            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Inventories)
                .HasForeignKey(i => i.ProductId);
            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Store)
                .WithMany(s => s.Inventories)
                .HasForeignKey(i => i.StoreId);
            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Employee)
                .WithMany(e => e.Inventories)
                .HasForeignKey(i => i.UpdateEmployeeId);

            modelBuilder.Entity<ManageProduct>()
                .HasOne(mp => mp.Product)
                .WithMany(p => p.ManageProducts)
                .HasForeignKey(mp => mp.ProductId);
            modelBuilder.Entity<ManageProduct>()
                .HasOne(mp => mp.Employee)
                .WithMany(e => e.ManageProducts)
                .HasForeignKey(mp => mp.EmployeeId);

            modelBuilder.Entity<ManageCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.ManageCategories)
                .HasForeignKey(mc => mc.CategoryId);
            modelBuilder.Entity<ManageCategory>()
                .HasOne(mc => mc.Employee)
                .WithMany(e => e.ManageCategories)
                .HasForeignKey(mc => mc.EmployeeId);

            modelBuilder.Entity<ManageSupplier>()
                .HasOne(ms => ms.Supplier)
                .WithMany(s => s.ManageSuppliers)
                .HasForeignKey(ms => ms.SupplierId);
            modelBuilder.Entity<ManageSupplier>()
                .HasOne(ms => ms.Employee)
                .WithMany(e => e.ManageSuppliers)
                .HasForeignKey(ms => ms.EmployeeId);
        }
    }
}
