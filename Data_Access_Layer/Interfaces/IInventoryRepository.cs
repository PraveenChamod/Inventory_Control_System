using Data_Access_Layer.DTOs.Inventory;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface IInventoryRepository
    {
        IEnumerable<GetInventoryDto> GetAllInventories();
        Task<Inventory> UpdateInventory(Guid productId, UpdateInventoryDto updateInventory, Guid employeeId, Guid storeId);
        Task<Inventory> CreateInventory(Guid? employeeId, Guid? storeId, Guid? productId);
    }
}
