using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? EmployeeID { get; set; }
        //[ForeignKey("EmployeeID")]
        //public virtual Employee Employee { get; set; }

        public int? CustomerID { get; set; }
        //[ForeignKey("CustomerID")]
        //public virtual Customer Customer { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }
    }
}
