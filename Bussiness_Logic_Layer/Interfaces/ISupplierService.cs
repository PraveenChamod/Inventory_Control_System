using Data_Access_Layer.DTOs.Supplier;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface ISupplierService
    {
        List<GetSupplierDto> GetSupplierList();
        Task<GetSupplierDto> CreateSupplier(CreateSupplierDto createSupplierDto);
    }
}
