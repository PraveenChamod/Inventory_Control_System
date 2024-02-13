using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Store;
using Data_Access_Layer.DTOs.Supplier;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Logic_Layer.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public List<GetSupplierDto> GetSupplierList()
        {
            var suppliers = _supplierRepository.GetAllSuppliers().Select(entity => _mapper.Map<GetSupplierDto>(entity)).ToList();
            return suppliers;
        }

        public async Task<GetSupplierDto> CreateSupplier(CreateSupplierDto createSupplierDto)
        {
            var name = createSupplierDto.SupplierName;
            var existingSupplier = _supplierRepository.GetAllSuppliers().FirstOrDefault(store => store.SupplierName == name);

            if (existingSupplier != null)
            {
                throw new Exception("Supplier with the same name already exists.");
            }

            var createdSupplier = await _supplierRepository.CreateSupplier(createSupplierDto);

            return _mapper.Map<GetSupplierDto>(createdSupplier);
        }

    }
}
