using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.Supplier;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Entities.Enums;
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

        public async Task<Supplier> CreateSupplier(CreateSupplierDto createSupplierDto, Guid? employeeId)
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
            if (employeeId != null)
            {
                await UpdateManageSupplier((Guid)newSupplier.Id!, (Guid)employeeId!, ManageItem.Create);
            }

            return newSupplier;
        }

        public async Task UpdateManageSupplier(Guid supplierId, Guid employeeId, ManageItem description)
        {
            var manageSupplier = new ManageSupplier
            {
                SupplierId = supplierId,
                EmployeeId = employeeId,
                Description = description,
                UpdateDate = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow
            };

            _dbContext.ManageSuppliers.Add(manageSupplier);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Supplier> UpdateSupplier(Guid supplierId, UpdateSupplierDto updateSupplierDto, Guid? employeeId)
        {
            var supplier = await _dbContext.Suppliers.FindAsync(supplierId);

            if (supplier != null)
            {
                supplier.SupplierName = updateSupplierDto.SupplierName;
                supplier.Phone = updateSupplierDto?.Phone;
                supplier.Email = updateSupplierDto?.Email;
                supplier.Street = updateSupplierDto?.Street;
                supplier.City = updateSupplierDto?.City;
                supplier.PostalCode = updateSupplierDto?.PostalCode;
                supplier.Country = updateSupplierDto?.Country;
                supplier.State = updateSupplierDto?.State;
                supplier.SupplierStatus = updateSupplierDto?.SupplierStatus;

                _dbContext.Suppliers.Update(supplier);
                await _dbContext.SaveChangesAsync();

                if (employeeId != null)
                {
                    await UpdateManageSupplier((Guid)supplier.Id!, (Guid)employeeId!, ManageItem.Update);
                }
            }
            return supplier!;
        }

        public async Task SoftDeleteSupplier(Guid supplierId, Guid employeeId)
        {
            var supplier = await _dbContext.Suppliers.FindAsync(supplierId);

            if (supplier != null)
            {
                supplier.SupplierStatus = ItemStatus.Inactive;
                _dbContext.Suppliers.Update(supplier);
                await UpdateManageSupplier(supplierId!, employeeId!, ManageItem.Remove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
