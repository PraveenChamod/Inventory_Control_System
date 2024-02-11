using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.Entities
{
    public class Category
    {
        public Guid? Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public ItemStatus? CategoryStatus { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<ManageCategory>? ManageCategories { get; set; }
    }
}
