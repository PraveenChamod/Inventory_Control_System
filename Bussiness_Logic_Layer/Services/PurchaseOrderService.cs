using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.PurchaseOrder;
using Data_Access_Layer.Interfaces;

namespace Bussiness_Logic_Layer.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository, IMapper mapper, IEmployeeRepository employeeRepository, ISupplierRepository supplierRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<GetPurchaseOrderDto> CreatePurchaseOrder(Guid employeeId, Guid supplierId, List<CreatePurchaseOrderDto> purchaseOrderItems)
        {
            var employee = _employeeRepository.GetAllEmployees().FirstOrDefault(e => e.Id == employeeId);
            var supplier = _supplierRepository.GetAllSuppliers().FirstOrDefault(e => e.Id == supplierId);

            if (employee == null)
            {
                throw new Exception("Employee does not exist.");
            }

            if (supplier == null)
            {
                throw new Exception("supplier does not exist.");
            }
            var createdPurchaseOrder = await _purchaseOrderRepository.CreatePurchaseOrder(employeeId, supplierId, purchaseOrderItems);

            return _mapper.Map<GetPurchaseOrderDto>(createdPurchaseOrder);
        }

    }
}
