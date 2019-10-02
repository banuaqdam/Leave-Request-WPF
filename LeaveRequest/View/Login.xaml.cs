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

namespace LeaveRequest.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
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

        private  void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            Roles role = new Roles();
            Forgot_Password forgot = new Forgot_Password();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.128.186:3019/api/");

            string Email = Txt_Email.Text;
            string Password = Txt_Password.Password;
            
            var response =  client.GetAsync("Roles/"+Email);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Roles>();
                readTask.Wait();
                role = readTask.Result;            
            }else
            {
                MessageBox.Show("Error Code" + result.StatusCode + " : Message - " + result.ReasonPhrase);
            }
        }
    }
}
