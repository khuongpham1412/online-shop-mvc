using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }
        public int Status { get; set; }
    }
}
