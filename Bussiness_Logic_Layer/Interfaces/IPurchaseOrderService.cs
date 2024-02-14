using Data_Access_Layer.DTOs.PurchaseOrder;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<GetPurchaseOrderDto> CreatePurchaseOrder(Guid employeeId, Guid supplierId, List<CreatePurchaseOrderDto> purchaseOrderItems);
    }
}
