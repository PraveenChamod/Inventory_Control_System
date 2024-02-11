using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class PurchaseOrder
    {
        public Guid? Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public ICollection<PurchaseOrderProduct>? PurchaseOrderProducts { get; set; }
    }
}
