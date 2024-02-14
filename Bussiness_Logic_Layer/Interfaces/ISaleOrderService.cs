using Data_Access_Layer.DTOs.SaleOrder;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface ISaleOrderService
    {
        Task<GetSaleOrderDto> CreateSaleOrder(Guid employeeId, List<CreateSaleOrderDto> saleOrderItems);

    }
}
