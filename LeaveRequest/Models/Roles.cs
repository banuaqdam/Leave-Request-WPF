using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequest.Models
{
    [Table("Tb_M_Roles")]
    public class Roles
    {
        [Key]
        public string Id { get; set; }
        public  string Role { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<User_Roles> User_Roles { get; set; }
    }
}
