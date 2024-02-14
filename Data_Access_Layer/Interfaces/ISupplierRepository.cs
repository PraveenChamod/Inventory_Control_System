using Data_Access_Layer.DTOs.Supplier;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<GetSupplierDto> GetAllSuppliers();
        Guid? GetIdBySupplierName(string name);
        Task<Supplier> CreateSupplier(CreateSupplierDto createSupplier, Guid? employeeId);
        Task UpdateManageSupplier(Guid supplierId, Guid employeeId, ManageItem description);
        Task<Supplier> UpdateSupplier(Guid supplierId, UpdateSupplierDto updateSupplier, Guid? employeeId);
        Task SoftDeleteSupplier(Guid supplierId, Guid employeeId);

    }
}
