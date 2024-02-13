using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.DTOs.Category
{
    public class GetCategoryDto
    {
        public Guid? Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public ItemStatus? CategoryStatus { get; set; }
    }
}
