using Data_Access_Layer.DTOs.Product;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<GetProductDto> GetAllProducts();
        Guid? GetIdByProductName(string name);
        Task<Product> CreateProduct(CreateProductDto createProduct, Guid? employeeId);
        Task UpdateManageProduct(Guid productId, Guid employeeId, ManageItem description);
        Task<Product> UpdateProduct(Guid productId, UpdateProductDto updateProduct, Guid? employeeId);
        Task SoftDeleteProduct(Guid productId, Guid employeeId);
    }
}
