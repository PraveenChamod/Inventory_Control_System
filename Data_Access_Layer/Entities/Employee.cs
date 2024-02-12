using Data_Access_Layer.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class Employee
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public Designation Designation { get; set; }
        public string? NIC { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? StoreId { get; set; }
        public Store? Store { get; set; }
        public ICollection<SaleOrder>? SaleOrders { get; set; }
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<ManageProduct>? ManageProducts { get; set; }
        public ICollection<ManageCategory>? ManageCategories { get; set; }
        public ICollection<ManageSupplier>? ManageSuppliers { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
