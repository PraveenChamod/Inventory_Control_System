using Data_Access_Layer.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public UserStatus UserStatus { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
