using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Product;
using Data_Access_Layer.Entities.Enums;
using Data_Access_Layer.Interfaces;

namespace Bussiness_Logic_Layer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<GetProductDto> GetProductList()
        {
            var products = _productRepository.GetAllProducts().Select(entity => _mapper.Map<GetProductDto>(entity)).ToList();
            return products;
        }

        public async Task<GetProductDto> CreateProduct(CreateProductDto createProductDto, Guid employeeId)
        {
            var name = createProductDto.ProductName;
            var existingProduct = _productRepository.GetAllProducts().FirstOrDefault(store => store.ProductName == name);

            if (existingProduct != null)
            {
                throw new Exception("Product with the same name already exists.");
            }

            var createdProduct = await _productRepository.CreateProduct(createProductDto, employeeId);

            return _mapper.Map<GetProductDto>(createdProduct);
        }

        public async Task<GetProductDto> UpdateProduct(Guid productId, UpdateProductDto updateProductDto, Guid employeeId)
        {
            var Product = _productRepository.GetAllProducts().FirstOrDefault(product => product.Id == productId);

            if (Product == null)
            {
                throw new Exception("Product is not exists.");
            }

            var updatedProduct = await _productRepository.UpdateProduct(productId, updateProductDto, employeeId);

            return _mapper.Map<GetProductDto>(updatedProduct);
        }

        public async Task SoftDeleteProduct(Guid productId, Guid employeeId)
        {
            var Product = _productRepository.GetAllProducts().FirstOrDefault(product => product.Id == productId);

            if (Product!.ProductStatus == ItemStatus.Inactive)
            {
                throw new Exception("Product is already removed.");
            }

            await _productRepository.SoftDeleteProduct(productId, employeeId);

        }
    }
}
