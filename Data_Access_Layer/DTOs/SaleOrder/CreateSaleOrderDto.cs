namespace Data_Access_Layer.DTOs.SaleOrder
{
    public class CreateSaleOrderDto
    {
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
