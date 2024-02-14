using Data_Access_Layer.DTOs.PurchaseOrder;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<PurchaseOrder> CreatePurchaseOrder(Guid? employeeId, Guid? supplierId, List<CreatePurchaseOrderDto> purchaseOrderItems);
    }
}
