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
            User_Roles _roles = new User_Roles();

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
    }
}
