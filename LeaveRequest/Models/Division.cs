using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequest.Models
{
    [Table("Tb_M_Division")]
    public  class Division
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
    }
}
