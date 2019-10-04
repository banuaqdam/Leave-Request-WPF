using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.Models;
using System.Data.Entity;

namespace LeaveRequest.Context
{
    class MyContext : DbContext
    {
        public MyContext() : base("LeaveRequest")
        {

        }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Leave_Data> Leave_Datas { get; set; }
        public DbSet<Leave_Status> Leave_Status { get; set; }
        public DbSet<Roles> Roless { get; set; }
        public DbSet<TR_Leave> TR_Leaves { get; set; }
        public DbSet<Type_Leave> Type_Leaves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<User_Roles> User_Roles { get; set; }
    }
}
