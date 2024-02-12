using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Store;
using Data_Access_Layer.Interfaces;

namespace Bussiness_Logic_Layer.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public List<GetStoreDto> GetStoreList()
        {
            var stores = _storeRepository.GetAllStores().Select(entity => _mapper.Map<GetStoreDto>(entity)).ToList();
            return stores;
        }

        public async Task<GetStoreDto> CreateStore(CreateStoreDto createStoreDto)
        {
            var name = createStoreDto.StoreName;
            var existingStore = _storeRepository.GetAllStores().FirstOrDefault(store => store.StoreName == name);

            if (existingStore != null)
            {
                throw new Exception("Store with the same name already exists.");
            }

            var createdStore = await _storeRepository.CreateStore(createStoreDto);

            return _mapper.Map<GetStoreDto>(createdStore);
        }
    }
}
