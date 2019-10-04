using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequest.Models
{
    [Table ("Tb_User_Roles")]
    public class User_Roles
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("User")]
        public int User_Id { get; set; }
        public User User { get; set; }
        [ForeignKey("Roles")]
        public string Roles_Id { get; set; }
        public Roles Roles { get; set; } 
    }
}
