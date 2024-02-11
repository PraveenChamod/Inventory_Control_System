namespace Data_Access_Layer.Entities
{
    public class SaleOrder
    {
        public Guid? Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<SaleOrderProduct>? SaleOrderProducts { get; set; }
    }
}
