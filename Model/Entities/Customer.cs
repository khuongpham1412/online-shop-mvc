using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int? AccountID { get; set; }

        [ForeignKey("AccountID")]
        public Account Account { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
