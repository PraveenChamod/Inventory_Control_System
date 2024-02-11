using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.Entities
{
    public class ManageSupplier
    {
        public Guid? Id { get; set; }
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public ManageItem? Description { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
