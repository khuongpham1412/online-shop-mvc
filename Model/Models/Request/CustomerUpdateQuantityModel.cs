using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Request
{
    public class CustomerUpdateQuantityModel
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
    }
}
