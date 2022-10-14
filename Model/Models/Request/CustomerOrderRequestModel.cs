using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Request
{
     public class CustomerOrderRequestModel : CustomerOrderModel
     {
        public int CustomerId { get; set; }
     }
}
