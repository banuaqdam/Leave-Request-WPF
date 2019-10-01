﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequest.Models
{
    [Table("Tb_M_Roles")]
    class Roles
    {
        [Key]
        public int Id { get; set; }
        public  string Role { get; set; }
        public bool isDeleted { get; set; }
    }
}