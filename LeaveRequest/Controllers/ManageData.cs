using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.Models;
using LeaveRequest.Context;
using System.Windows;

namespace LeaveRequest.Controllers
{
    public class ManageData
    {
        public void addHoliday(string name,DateTime sDate,DateTime eDate)
        {
            var result = 0;
            Holiday _holiday = new Holiday();
            MyContext _context = new MyContext();

            _holiday.Name = name;
            _holiday.StartDate = sDate;
            _holiday.EndDate = eDate;
            _holiday.isDeleted = false;
            _context.Holidays.Add(_holiday);
            result = _context.SaveChanges();

            if (result > 0)
            {
                MessageBox.Show("Add Data Supplier Successful!");
            }
            else
            {
                MessageBox.Show("Add Data Supplier Failed!");
            }
        }
        public void DeleteTypeLeave(int id)
        {
            var result = 0;
            
            Type_Leave _type = new Type_Leave();
            MyContext _context = new MyContext();

            var get = _context.Type_Leaves.Find(id);

            if (get == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                get.isDeleted = true;
                result = _context.SaveChanges();
                if (result > 0)
                {
                    MessageBox.Show("Delete Successfully");
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                }

            }
        }
        public void Update_TypeLeave(int id, string _name, int _duration)
        {
            var result = 0;

            Type_Leave _type = new Type_Leave();
            MyContext _context = new MyContext();

            var get = _context.Type_Leaves.Find(id);

            if (get == null)
            {
                MessageBox.Show("Data not found!");
            }
            else
            {
                get.Name = _name;
                get.Duration = _duration;
                result = _context.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("Update Success!");
                }
                else
                {
                    MessageBox.Show("Update Failed!");
                }
            }
        }
        public void Update_Holiday(int id, string _name, DateTime sDate, DateTime eDate)
        {
            var result = 0;

            Holiday _type = new Holiday();
            MyContext _context = new MyContext();

            var get = _context.Holidays.Find(id);

            if (get == null)
            {
                MessageBox.Show("Data not found!");
            }
            else
            {
                get.Name = _name;
                get.StartDate = sDate;
                get.EndDate = eDate;
                result = _context.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("Update Success!");
                }
                else
                {
                    MessageBox.Show("Update Failed!");
                }
            }
        }
        public void DeleteHoliday(int id)
        {
            var result = 0;

            Holiday _type = new Holiday();
            MyContext _context = new MyContext();

            var get = _context.Holidays.Find(id);

            if (get == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                get.isDeleted = true;
                result = _context.SaveChanges();
                if (result > 0)
                {
                    MessageBox.Show("Delete Successfully");
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                }

            }
        }
    }
}
