using Data_Access_Layer.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class Supplier
    {
        public Guid? Id { get; set; }
        public string? SupplierName { get; set; }
        public string? Phone { get; set;}
        public string? Email { get; set;}
        public string? Street { get; set;}
        public string? City { get; set;}
        public string? State { get; set;}
        public string? PostalCode { get; set;}
        public string? Country { get; set;}
        public ItemStatus? SupplierStatus { get; set; }
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<ManageSupplier>? ManageSuppliers { get; set; }

    }
}
