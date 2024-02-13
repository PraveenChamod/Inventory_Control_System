using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.DTOs.Supplier
{
    public class CreateSupplierDto
    {
        public string? SupplierName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public ItemStatus? SupplierStatus { get; set; } = ItemStatus.Active;
    }
}
