using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveRequest.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        [Key]
        public string NIK { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public string Personal_Email { get; set;}
        public string Place_Of_Birth { get; set; }
        public string Birth_Date { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Employee_Status { get; set; }
        public String Marital_Status { get; set; }
        public int Number_Of_Children { get; set; }
        public int Last_Year_Request { get; set; }
        public int Current_Leave_Request { get; set; }
        public int Last_Year_Before { get; set; }
        public int Current_Leave_Before { get; set; }
        public bool isDeleted { get; set; }
        [ForeignKey("Manager")]
        public string Manager_Id { get; set; }
        public Employee Manager { get; set; }
        [ForeignKey("Department")]
        public string Department_Id { get; set; }
        public Department Department { get; set; }

    }
}
