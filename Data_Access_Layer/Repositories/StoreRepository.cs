using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.Store;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StoreRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public IEnumerable<GetStoreDto> GetAllStores()
        {
            return _dbContext.Stores
                .Select(s => new GetStoreDto
                {
                    Id = s.Id,
                    StoreName = s.StoreName
                })
                .ToList();
        }

        public Guid? GetIdByStoreName(string name)
        {
            var id = _dbContext.Stores
                .Where(t => t.StoreName!.Replace(" ", string.Empty) == name)
                .FirstOrDefault()?
                .Id;
            return id;
        }

        public async Task<Store> CreateStore(CreateStoreDto createStoreDto)
        {
            var newStore = new Store
            {
                Id = createStoreDto.Id,
                StoreName = createStoreDto.StoreName,
                Phone = createStoreDto.Phone,
                Email = createStoreDto.Email,
                Street = createStoreDto.Street,
                City = createStoreDto.City,
                State = createStoreDto.State,
                PostalCode = createStoreDto.PostalCode,
                Country = createStoreDto.Country
            };
            _dbContext.Stores.Add(newStore);
            await _dbContext.SaveChangesAsync();
            return newStore;
        }
    }
}
