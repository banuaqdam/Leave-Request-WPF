using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequest.Models
{
    [Table("Tb_Leave_Data")]
    public class Leave_Data
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateAt { get; set; }
        [ForeignKey("Type_Leave")]
        public int Type_Leave_ID { get; set; }
        public Type_Leave Type_Leave { get; set; }
        [ForeignKey("Employee")]
        public string NIK { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Manager")]
        public string Manager_Id { get; set; }
        public Employee Manager { get; set; }

    }
}
