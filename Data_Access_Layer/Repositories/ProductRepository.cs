using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.Product;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Entities.Enums;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GetProductDto> GetAllProducts()
        {
            return _dbContext.Products
                .Select(s => new GetProductDto
                {
                    Id = s.Id,
                    ProductName = s.ProductName,
                    ProductDescription = s.ProductDescription,
                    UnitPrice = s.UnitPrice,
                    CategoryId = s.CategoryId,
                    SupplierId = s.SupplierId,
                    ProductStatus = s.ProductStatus,
                })
                .ToList();
        }

        public Guid? GetIdByProductName(string name)
        {
            var id = _dbContext.Products
                .Where(t => t.ProductName!.Replace(" ", string.Empty) == name)
                .FirstOrDefault()?
                .Id;
            return id;
        }

        public async Task<Product> CreateProduct(CreateProductDto createProductDto, Guid? employeeId)
        {
            var newProduct = new Product
            {
                ProductName = createProductDto.ProductName,
                ProductDescription = createProductDto.ProductDescription,
                UnitPrice = createProductDto.UnitPrice,
                CategoryId = createProductDto.CategoryId,
                SupplierId = createProductDto.SupplierId,
                ProductStatus = createProductDto.ProductStatus,

            };
            _dbContext.Products.Add(newProduct);
            await _dbContext.SaveChangesAsync();

            if (employeeId != null)
            {
                await UpdateManageProduct((Guid)newProduct.Id!, (Guid)employeeId!, ManageItem.Create);
            }
            return newProduct;
        }

        public async Task<Product> UpdateProduct(Guid productId, UpdateProductDto updateProductDto, Guid? employeeId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null)
            {
                product.ProductName = updateProductDto.ProductName;
                product.ProductDescription = updateProductDto.ProductDescription;
                product.UnitPrice = updateProductDto.UnitPrice;
                product.CategoryId = updateProductDto.CategoryId;
                product.SupplierId = updateProductDto.SupplierId;
                product.ProductStatus = updateProductDto.ProductStatus;

                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();

                if (employeeId != null)
                {
                    await UpdateManageProduct((Guid)product.Id!, (Guid)employeeId!, ManageItem.Update);
                }
            }
            return product!;
        }

        public async Task UpdateManageProduct(Guid productId, Guid employeeId, ManageItem description)
        {
            var manageProduct = new ManageProduct
            {
                ProductId = productId,
                EmployeeId = employeeId,
                Description = description,
                UpdateDate = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow
            };

            _dbContext.ManageProducts.Add(manageProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteProduct(Guid productId , Guid employeeId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null)
            {
                product.ProductStatus = ItemStatus.Inactive;
                _dbContext.Products.Update(product);
                await UpdateManageProduct(productId!, employeeId!, ManageItem.Remove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
