using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Response
{
    public class CustomerOrderModel
    {
        public int BillId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DateCreate { get; set; }
        public decimal Total { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Status { get; set; }
    }
}
