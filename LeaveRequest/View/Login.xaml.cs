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
using System.Net.Http;
using System.Net.Http.Headers;
using LeaveRequest.Models;
using LeaveRequest.Controllers;
using LeaveRequest.Context;

namespace LeaveRequest.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public object User_controller { get; private set; }

        public Login()
        {
            InitializeComponent();
        }
        private void Chk_Remember_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_Forgot_Click(object sender, RoutedEventArgs e)
        {
            Forgot_Password forgot = new Forgot_Password();

            this.Hide();
            forgot.Show();
            this.Close();
        }
        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            User_Controller _user = new User_Controller();
            MyContext _contex = new MyContext();

            if(Txt_Email.Text.Length != 0 && Txt_Password.Password.Length != 0)
            {
                string email = Txt_Email.Text;
                string password = Txt_Password.Password;
                var get = _contex.Users.Where(u => u.Email == email).FirstOrDefault<User>();
                string NIK = get.Employee_Id;
                var status = _user.UserLogin(email, password);
                if (status == true)
                {
                    this.Hide();
                    Home home = new Home(NIK);
                    home.Show();
                }
            }
            else
            {
                MessageBox.Show("Please Fill All The Requirement!");
            }
            
        }
    }
}
