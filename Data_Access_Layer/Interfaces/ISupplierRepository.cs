using Data_Access_Layer.DTOs.Supplier;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<GetSupplierDto> GetAllSuppliers();
        Guid? GetIdBySupplierName(string name);
        Task<Supplier> CreateSupplier(CreateSupplierDto createSupplier);
    }
}
