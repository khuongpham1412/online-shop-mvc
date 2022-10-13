using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Request
{
     public class CustomerOrderRequestModel
     {
        public int CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }   
        public int ProductId { get; set; }
     }
}
