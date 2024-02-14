namespace Data_Access_Layer.DTOs.SaleOrder
{
    public class GetSaleOrderDto
    {
        public Guid? Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
