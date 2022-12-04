using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Request
{
    public class InsertProductRequestModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public IList<int> SizeId { get; set; }
        public IList<int> ColorId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
