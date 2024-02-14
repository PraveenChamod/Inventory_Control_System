using Data_Access_Layer.DTOs.Inventory;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface IInventoryService
    {
        List<GetInventoryDto> GetInventoryList();
        Task<GetInventoryDto> UpdateInventory(Guid productId, UpdateInventoryDto updateInventory, Guid employeeId, Guid storeId);
        Task<GetInventoryDto> CreateInventory(Guid employeeId, Guid storeId, Guid productId);

    }
}
