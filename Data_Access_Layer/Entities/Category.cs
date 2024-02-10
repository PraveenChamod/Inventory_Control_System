using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class Category
    {
        [Key]
        public Guid? ID { get; } = Guid.NewGuid();
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
