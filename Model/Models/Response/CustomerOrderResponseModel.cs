using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Response
{
    public class CustomerOrderResponseModel : CustomerOrderModel
    {
        public string PathImage { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
    }
}
