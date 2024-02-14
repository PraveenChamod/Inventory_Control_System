using Data_Access_Layer.Entities;
using Data_Access_Layer.Context;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.DTOs.SaleOrder;

namespace Data_Access_Layer.Repositories
{
    public class SaleOrderRepository : ISaleOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SaleOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SaleOrder> CreateSaleOrder(Guid? employeeId, List<CreateSaleOrderDto> saleOrderItems)
        {
            var newSaleOrder = new SaleOrder
            {
                Date = DateTime.UtcNow,
                Time = DateTime.UtcNow,
                EmployeeId = employeeId
            };
            _dbContext.SaleOrders.Add(newSaleOrder);
            await _dbContext.SaveChangesAsync();
            foreach (var item in saleOrderItems)
            {
                var newSaleOrderProduct = new SaleOrderProduct
                {
                    SaleOrderId = newSaleOrder.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };
                _dbContext.SaleOrderProducts.Add(newSaleOrderProduct);
            }
            await _dbContext.SaveChangesAsync();
            return newSaleOrder;
        }
    }
}
