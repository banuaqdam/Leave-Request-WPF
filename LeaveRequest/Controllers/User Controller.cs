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
    public class User_Controller
    {

        public bool UserLogin(string _email, string _password)
        {
            User User = new User();
            MyContext Context = new MyContext();
            //User_Roles _roles = new User_Roles();

            //var getRole  = Context.User_Roles.Join(Context.Users,p=>Us)
            
            var get = Context.Users.Where(u => u.Email == _email).FirstOrDefault<User>();
            if (get == null)
            {
                MessageBox.Show("You are not Registered yet!");
                return false;
            }
            else
            {
                if (get.Password != _password)
                {
                    MessageBox.Show("Your Password is Incorrect!");
                    return false;
                }
                else
                {
                    MessageBox.Show("Login Successful!");
                }
            }
            return true;
        }

        public void ChangePass(string oldpassword, string newpassword)
        {
            var result = 0;

            User user = new User();
            MyContext _context = new MyContext();


            var get = _context.Users.Where(u => u.Password == oldpassword).FirstOrDefault<User>();

            if (get == null)
            {
                MessageBox.Show("Your Password is Incorect");
            }
            else
            {
                if (get.Password != newpassword)
                {
                    get.Password = newpassword;
                    result = _context.SaveChanges();

                    if (result > 0)
                    {
                        MessageBox.Show("Update Succes!");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Your Password Can't be the same");
                }

            }
        }
    }
}
