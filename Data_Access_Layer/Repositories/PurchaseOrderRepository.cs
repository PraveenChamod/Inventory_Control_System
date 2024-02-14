using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.PurchaseOrder;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PurchaseOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PurchaseOrder> CreatePurchaseOrder(Guid? employeeId, Guid? supplierId, List<CreatePurchaseOrderDto> purchaseOrderItems)
        {
            var newPurchaseOrder = new PurchaseOrder 
            {
                Date = DateTime.UtcNow,
                Time = DateTime.UtcNow,
                EmployeeId = employeeId,
                SupplierId = supplierId
            };
            _dbContext.PurchaseOrders.Add(newPurchaseOrder);
            await _dbContext.SaveChangesAsync();
            foreach (var item in purchaseOrderItems)
            {
                var newPurchaseOrderProduct = new PurchaseOrderProduct
                {
                    PurchaseOrderId = newPurchaseOrder.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };
                _dbContext.PurchaseOrderProducts.Add(newPurchaseOrderProduct);
            }
            await _dbContext.SaveChangesAsync();
            return newPurchaseOrder;
        }
    }
}
