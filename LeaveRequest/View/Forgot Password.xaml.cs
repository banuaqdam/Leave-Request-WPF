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
    /// Interaction logic for Forgot_Password.xaml
    /// </summary>
    public partial class Forgot_Password : Window
    {
        public Forgot_Password()
        {
            InitializeComponent();
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();

            this.Hide();
            login.Show();
            this.Close();
        }
    }
}
