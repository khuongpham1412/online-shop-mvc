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
        public int? ProductID { get; set; }
        //[ForeignKey("ProductID")]
        //public Product Product { get; set; }

        public int SizeID { get; set; }
        //[ForeignKey("SizeID")]
        //public Size Size { get; set; }

        public int ColorID { get; set; }
        //[ForeignKey("ColorID")]
        //public Color Color { get; set; }

        public int Quantity { get; set; }
    }
}
