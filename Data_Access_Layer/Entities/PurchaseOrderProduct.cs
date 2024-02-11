namespace Data_Access_Layer.Entities
{
    public class PurchaseOrderProduct
    {
        public Guid? PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? Quantity { get; set; }
    }
}
