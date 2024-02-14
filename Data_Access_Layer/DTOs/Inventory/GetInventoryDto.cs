using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.DTOs.Inventory
{
    public class GetInventoryDto
    {
        public Guid? ProductId { get; set; }
        public Guid? StoreId { get; set; }
        public int? MaximumStockCount { get; set; }
        public int? MinimumStockCount { get; set; }
        public int? AvailableStockCount { get; set; }
    }
}
