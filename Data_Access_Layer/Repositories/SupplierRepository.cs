using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.Supplier;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SupplierRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GetSupplierDto> GetAllSuppliers()
        {
            return _dbContext.Suppliers
                .Select(s => new GetSupplierDto
                {
                    Id = s.Id,
                    SupplierName = s.SupplierName,
                    Phone = s.Phone,
                    Email = s.Email,
                    Street = s.Street,
                    City = s.City,
                    PostalCode = s.PostalCode,
                    Country = s.Country,
                    State = s.State,
                    SupplierStatus = s.SupplierStatus,  
                })
                .ToList();
        }

        public Guid? GetIdBySupplierName(string name)
        {
            var id = _dbContext.Suppliers
                .Where(t => t.SupplierName!.Replace(" ", string.Empty) == name)
                .FirstOrDefault()?
                .Id;
            return id;
        }

        public async Task<Supplier> CreateSupplier(CreateSupplierDto createSupplierDto)
        {
            var newSupplier = new Supplier
            {
                SupplierName = createSupplierDto.SupplierName,
                Phone = createSupplierDto.Phone,
                Email = createSupplierDto.Email,
                Street = createSupplierDto.Street,
                City = createSupplierDto.City,
                PostalCode = createSupplierDto.PostalCode,
                Country = createSupplierDto.Country,
                State = createSupplierDto.State,
                SupplierStatus = createSupplierDto.SupplierStatus,

            };
            _dbContext.Suppliers.Add(newSupplier);
            await _dbContext.SaveChangesAsync();
            return newSupplier;
        }
    }
}
