using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Response
{
    public class InfomationUserAccountModelResponse
    {
        public int? AccountId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public int Status { get; set; }
    }
}
