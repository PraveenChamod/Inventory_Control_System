using Data_Access_Layer.DTOs.SaleOrder;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface ISaleOrderRepository
    {
        Task<SaleOrder> CreateSaleOrder(Guid? employeeId, List<CreateSaleOrderDto> saleOrderItems);
    }
}
