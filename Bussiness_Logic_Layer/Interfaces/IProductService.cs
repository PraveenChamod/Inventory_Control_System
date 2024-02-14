using Data_Access_Layer.DTOs.Product;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface IProductService
    {
        List<GetProductDto> GetProductList();
        Task<GetProductDto> CreateProduct(CreateProductDto createProductDto, Guid employeeId);
        Task<GetProductDto> UpdateProduct(Guid productId, UpdateProductDto updateProductDto, Guid employeeId);
        Task SoftDeleteProduct(Guid productId, Guid employeeId);
    }
}
