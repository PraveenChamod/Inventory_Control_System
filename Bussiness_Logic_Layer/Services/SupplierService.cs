using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Store;
using Data_Access_Layer.DTOs.Supplier;
using Data_Access_Layer.Entities.Enums;
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

        public async Task<GetSupplierDto> CreateSupplier(CreateSupplierDto createSupplierDto, Guid employeeId)
        {
            var name = createSupplierDto.SupplierName;
            var existingSupplier = _supplierRepository.GetAllSuppliers().FirstOrDefault(store => store.SupplierName == name);

            if (existingSupplier != null)
            {
                throw new Exception("Supplier with the same name already exists.");
            }

            var createdSupplier = await _supplierRepository.CreateSupplier(createSupplierDto, employeeId);

            return _mapper.Map<GetSupplierDto>(createdSupplier);
        }

        public async Task<GetSupplierDto> UpdateSupplier(Guid supplierId, UpdateSupplierDto updateSupplierDto, Guid employeeId)
        {
            var supplier = _supplierRepository.GetAllSuppliers().FirstOrDefault(s => s.Id == supplierId);

            if (supplier == null)
            {
                throw new Exception("Supplier does not exist.");
            }

            var updatedSupplier = await _supplierRepository.UpdateSupplier(supplierId, updateSupplierDto, employeeId);

            return _mapper.Map<GetSupplierDto>(updatedSupplier);
        }

        public async Task SoftDeleteSupplier(Guid supplierId, Guid employeeId)
        {
            var supplier = _supplierRepository.GetAllSuppliers().FirstOrDefault(s => s.Id == supplierId);

            if (supplier!.SupplierStatus == ItemStatus.Inactive)
            {
                throw new Exception("Supplier is already removed.");
            }

            await _supplierRepository.SoftDeleteSupplier(supplierId, employeeId);
        }


    }
}
