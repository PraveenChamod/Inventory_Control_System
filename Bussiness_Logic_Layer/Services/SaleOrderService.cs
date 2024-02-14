using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.SaleOrder;
using Data_Access_Layer.Interfaces;

namespace Bussiness_Logic_Layer.Services
{
    public class SaleOrderService : ISaleOrderService
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public SaleOrderService(ISaleOrderRepository saleOrderRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _saleOrderRepository = saleOrderRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<GetSaleOrderDto> CreateSaleOrder(Guid employeeId, List<CreateSaleOrderDto> saleOrderItems)
        {
            var employee = _employeeRepository.GetAllEmployees().FirstOrDefault(employee => employee.Id == employeeId);

            if (employee == null)
            {
                throw new Exception("Employee does not exist.");
            }

            var createdSaleOrder = await _saleOrderRepository.CreateSaleOrder(employeeId, saleOrderItems);

            return _mapper.Map<GetSaleOrderDto>(createdSaleOrder);
        }
    }
}
