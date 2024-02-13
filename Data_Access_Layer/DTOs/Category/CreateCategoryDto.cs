using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public ItemStatus? CategoryStatus { get; set; } = ItemStatus.Active;
    }
}
