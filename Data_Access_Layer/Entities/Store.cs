using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class Store
    {
        public Guid? Id { get; set; }
        public string? StoreName { get; set; }
        public string? Phone { get; set;}
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
    }
}
