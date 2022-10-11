using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }

    }
}
