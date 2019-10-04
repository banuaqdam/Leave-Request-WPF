using LeaveRequest.Context;
using LeaveRequest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LeaveRequest.View
{
    /// <summary>
    /// Interaction logic for Change_Password.xaml
    /// </summary>
    public partial class Change_Password : Window
    {
        public string G_NIK;
        public Change_Password(string NIK)
        {
            InitializeComponent();
            setNIK(NIK);
            setName(NIK);
        }
        public void setNIK(string NIK)
        {
            G_NIK = NIK;
        }
        public void setName(string NIK)
        {
            MyContext _context = new MyContext();
            var get = _context.Employees.Find(NIK);
            string FName = get.First_Name;
            string LName = get.Last_Name;
        }
        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            User_Controller Controller = new User_Controller();

            if (Txt_OldPassword.Password.Length == 0 && Txt_NewPassword.Password.Length == 0 && Txt_VerifyPassword.Password.Length == 0)
            {
                OldPasswordErrorMassage.Text = "Enter your Old Password";
                NewPasswordErrorMassage.Text = "Enter your New Password";
                VerifyPasswordErrorMassage.Text = "Enter your Verify Password"; 
                Txt_OldPassword.Focus();
            }
            else if (Txt_OldPassword.Password.Length == 0 && Txt_VerifyPassword.Password.Length == 0)
            {
                OldPasswordErrorMassage.Text = "Enter your Old Password";
                VerifyPasswordErrorMassage.Text = "Enter your Verify Password";
                Txt_OldPassword.Focus();
            }
            else if (Txt_NewPassword.Password.Length == 0 && Txt_VerifyPassword.Password.Length == 0)
            {
                NewPasswordErrorMassage.Text = "Enter your New Password";
                VerifyPasswordErrorMassage.Text = "Enter your Verify Password";
                Txt_NewPassword.Focus();
            }
            else if (Txt_OldPassword.Password.Length == 0)
            {
                OldPasswordErrorMassage.Text = "Enter your Old Password";               
                Txt_OldPassword.Focus();
            }
            else if (Txt_NewPassword.Password.Length == 0)
            {
                NewPasswordErrorMassage.Text = "Enter your New Password";
                Txt_NewPassword.Focus();
            }
            else if (Txt_VerifyPassword.Password.Length == 0)
            {
                VerifyPasswordErrorMassage.Text = "Enter your Verify Password";
                Txt_VerifyPassword.Focus();
            }
            else if (Txt_OldPassword.Password == Txt_NewPassword.Password)
            {
                NewPasswordErrorMassage.Text = "Password Can't Be Same";
                Txt_OldPassword.Focus();
            }
            else if (Txt_VerifyPassword.Password != Txt_NewPassword.Password)
            {
                NewPasswordErrorMassage.Text = "Verify Password Must Be Same";
                Txt_NewPassword.Focus();
            }
            else
            {
                string oldpassword = Txt_OldPassword.Password;
                string newpassword = Txt_NewPassword.Password;

                Controller.ChangePass(oldpassword, newpassword);
                this.Hide();
                Home home = new Home(G_NIK);
                home.Show();
            }
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Home home = new Home(G_NIK);
            home.Show();
            this.Close();
        }
    }
}
