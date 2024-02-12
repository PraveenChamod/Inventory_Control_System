using Data_Access_Layer.DTOs.Store;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface IStoreRepository
    {
        IEnumerable<GetStoreDto> GetAllStores();
        Guid? GetIdByStoreName(string name);
        Task<Store> CreateStore(CreateStoreDto createStore);
    }
}
