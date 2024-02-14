using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Inventory;
using Data_Access_Layer.Interfaces;

namespace Bussiness_Logic_Layer.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper, IProductRepository productRepository)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public List<GetInventoryDto> GetInventoryList()
        {
            var Inventories = _inventoryRepository.GetAllInventories().Select(entity => _mapper.Map<GetInventoryDto>(entity)).ToList();
            return Inventories;
        }

        public async Task<GetInventoryDto> UpdateInventory(Guid productId, UpdateInventoryDto updateInventory, Guid employeeId, Guid storeId)
        {
            var inventory = _inventoryRepository.GetAllInventories().FirstOrDefault(i => i.ProductId == productId && i.StoreId == storeId);
            var product = _productRepository.GetAllProducts().FirstOrDefault(product => product.Id == productId);

            if (inventory == null)
            {
                if(product == null)
                {
                    throw new Exception("Product does not exist.");
                }
                else
                {
                    throw new Exception("Ensure inventory is cretaed for product.");
                } 
            }
            var updatedInventory = await _inventoryRepository.UpdateInventory(productId, updateInventory, employeeId, storeId);

            return _mapper.Map<GetInventoryDto>(updatedInventory);
        }

        public async Task<GetInventoryDto> CreateInventory(Guid employeeId, Guid storeId, Guid productId)
        {
            var existingInventory = _inventoryRepository.GetAllInventories().FirstOrDefault(i => i.ProductId == productId && i.StoreId == storeId);

            if (existingInventory != null)
            {
                throw new Exception("Inventory for the same product already exists in this store");
            }

            var createdInventory = await _inventoryRepository.CreateInventory(employeeId, storeId, productId);

            return _mapper.Map<GetInventoryDto>(createdInventory);
        }

    }
}
