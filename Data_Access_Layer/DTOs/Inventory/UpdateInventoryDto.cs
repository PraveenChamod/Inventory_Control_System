using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.DTOs.Inventory
{
    public class UpdateInventoryDto
    {
        public int? MaximumStockCount { get; set; }
        public int? MinimumStockCount { get; set; }
        public int? AvailableStockCount { get; set; }
        public InventoryUpdate UpdateDescription { get; set; }
    }
}
