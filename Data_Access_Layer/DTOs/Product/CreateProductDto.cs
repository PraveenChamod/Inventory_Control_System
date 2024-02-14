using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.DTOs.Product
{
    public class CreateProductDto
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? UnitPrice { get; set;}
        public Guid? CategoryId { get; set; }
        public Guid? SupplierId { get; set; }
        public ItemStatus? ProductStatus { get; set; } = ItemStatus.Active;
    }
}
