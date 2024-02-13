using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public required string Name { get; set; }
        public Designation Designation { get; set; }
        public string? NIC { get; set; }
        public string? Phone { get; set; }
        public required string Email { get; set; }
        public required string? Password { get; set; }
        public Guid? StoreId { get; set; }
    }
}
