using Data_Access_Layer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class ManageCategory
    {
        public Guid? Id { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public ManageItem? Description { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
