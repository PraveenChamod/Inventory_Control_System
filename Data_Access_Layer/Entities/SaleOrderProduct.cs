namespace Data_Access_Layer.Entities
{
    public class SaleOrderProduct
    {
        public Guid? SaleOrderId { get; set; }
        public SaleOrder? SaleOrder { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? Quantity { get; set; }
    }
}
