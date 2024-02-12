using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.DTOs.Employee
{
    public class GetEmployeeDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public Designation Designation { get; set; }
        public string? NIC { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? StoreId { get; set; }
    }
}
