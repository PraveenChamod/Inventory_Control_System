using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.Inventory;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Entities.Enums;
using Data_Access_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data_Access_Layer.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InventoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GetInventoryDto> GetAllInventories()
        {
            return _dbContext.Inventories
                .Select(s => new GetInventoryDto
                {
                    ProductId = s.ProductId,
                    StoreId = s.StoreId,
                    MaximumStockCount = s.MaximumStockCount,
                    MinimumStockCount = s.MinimumStockCount,
                    AvailableStockCount = s.AvailableStockCount,
                })
                .ToList();
        }

        public async Task<Inventory> CreateInventory(Guid? employeeId, Guid? storeId, Guid? productId)
        {
            var newInventory = new Inventory
            {
                MaximumStockCount = 0,
                MinimumStockCount = 0,
                AvailableStockCount = 0,
                UpdateTime = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                UpdateDescription = InventoryUpdate.Create,
                ProductId = productId,
                StoreId = storeId,
                UpdateEmployeeId = employeeId
            };
            _dbContext.Inventories.Add(newInventory);
            await _dbContext.SaveChangesAsync();
            return newInventory!;
        }


        public async Task<Inventory> UpdateInventory(Guid productId, UpdateInventoryDto updateInventory, Guid employeeId, Guid storeId)
        {
            var inventory = await _dbContext.Inventories.FirstOrDefaultAsync(i => i.ProductId == productId && i.StoreId == storeId);

            if (inventory != null)
            {
                inventory.MaximumStockCount = updateInventory.MaximumStockCount;
                inventory.MinimumStockCount = updateInventory.MinimumStockCount;
                inventory.AvailableStockCount = updateInventory.AvailableStockCount;
                inventory.UpdateDescription = updateInventory.UpdateDescription;

                _dbContext.Inventories.Update(inventory);
                await _dbContext.SaveChangesAsync();
            }
            return inventory!;
        }
    }
}
