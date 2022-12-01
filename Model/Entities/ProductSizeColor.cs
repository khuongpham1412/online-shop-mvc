using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class ProductSizeColor
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }

        public int Quantity { get; set; }
    }
}
