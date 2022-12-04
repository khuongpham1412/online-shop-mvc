using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Response
{
    public class ProductResponseModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public IList<int> SizeId { get; set; }
        public IList<int> ColorId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
