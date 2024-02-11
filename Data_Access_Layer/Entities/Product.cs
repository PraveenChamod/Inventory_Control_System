using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.Entities
{
    public class Product
    {
        public Guid? Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? UnitPrice { get; set;}
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public ItemStatus? ProductStatus { get; set; }
        public ICollection<SaleOrderProduct>? SaleOrderProducts { get; set; }
        public ICollection<PurchaseOrderProduct>? PurchaseOrderProducts { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<ManageProduct>? ManageProducts { get; set; }
    }
}
