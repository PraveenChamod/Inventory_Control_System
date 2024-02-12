using Data_Access_Layer.DTOs.Store;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface IStoreService
    {
        List<GetStoreDto> GetStoreList();
        Task<GetStoreDto> CreateStore(CreateStoreDto createStoreDto);
    }
}
