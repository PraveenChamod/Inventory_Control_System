using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.Entities
{
    public class Inventory
    {
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid? StoreId { get; set; }
        public Store? Store { get; set; }
        public int? MaximumStockCount { get; set; }
        public int? MinimumStockCount { get; set; }
        public int? AvailableStockCount { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? UpdateDate { get; set; }
        public InventoryUpdate UpdateDescription { get; set; }
        public Guid? UpdateEmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
