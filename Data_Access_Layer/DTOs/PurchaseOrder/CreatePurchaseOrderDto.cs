namespace Data_Access_Layer.DTOs.PurchaseOrder
{
    public class CreatePurchaseOrderDto
    {
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
