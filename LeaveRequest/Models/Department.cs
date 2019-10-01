using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequest.Models
{
    [Table("Tb_M_Department")]
    class Department
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        [ForeignKey("Division")]
        public string Divison_Id
        public Division Division { get; set; }
    }
}
