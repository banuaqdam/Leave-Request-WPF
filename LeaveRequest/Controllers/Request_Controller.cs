using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.Context;
using LeaveRequest.Models;
using System.Windows;

namespace LeaveRequest.Controllers
{
    class Request_Controller 
    {
        public bool addRequest(string NIK, DateTime StartDate, DateTime EndDate, int crnt, int lst)
        {
            MyContext _contex = new MyContext();
            Leave_Data leave_data = new Leave_Data();
            Employee _employee = new Employee();
            TR_Leave _tr = new TR_Leave();

            var result = 0;
            var getEmp = _contex.Employees.Find(NIK);
            string _name = ""+ getEmp.First_Name + " " + getEmp.Last_Name + "";

            leave_data.NIK = getEmp.NIK;
            leave_data.Name = _name;
            leave_data.StartDate = Convert.ToDateTime(StartDate);
            leave_data.EndDate = Convert.ToDateTime(EndDate);
            leave_data.Type_Leave_ID = 1;
            leave_data.CreateAt = DateTime.Now;
            leave_data.Manager_Id = getEmp.Manager_Id;

            var get = _contex.Employees.Find(NIK);
            get.Current_Leave_Before = get.Current_Leave_Request;
            get.Last_Year_Before = get.Last_Year_Request;
            get.Current_Leave_Request = crnt;
            get.Last_Year_Request = lst;

            _contex.Leave_Datas.Add(leave_data);
            result = _contex.SaveChanges();
            var getMax = _contex.Leave_Datas.Max(u => u.Id);
            addTR(getMax);

            if (result > 0)
            {
                MessageBox.Show("Add Leave Request Successful!");
            }
            else
            {
                MessageBox.Show("Add Leave Request Failed!");
            }

            return false;
        }
        public void addTR(int id)
        {
            MyContext _context = new MyContext();
            TR_Leave _tr = new TR_Leave();

            _tr.Leave_Data_Id = id;
            _tr.Leave_Status_Id = 1;
            _context.TR_Leaves.Add(_tr);
            _context.SaveChanges();
        }
    }
}
