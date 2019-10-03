using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequest.Models
{
    [Table("Tb_M_Leave_Status")]
    public class Leave_Status
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<TR_Leave> TR_Leaves { get; set; }
    }
}
