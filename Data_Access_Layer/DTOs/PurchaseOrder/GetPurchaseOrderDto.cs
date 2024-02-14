namespace Data_Access_Layer.DTOs.PurchaseOrder
{
    public class GetPurchaseOrderDto
    {
        public Guid? Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? SupplierId { get; set; }
    }
}
