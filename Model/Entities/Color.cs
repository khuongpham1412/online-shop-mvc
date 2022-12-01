using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        public IList<ProductSizeColor> ProductSizeColors { get; set; }
    }
}
