using LeaveRequest.Context;
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

        private void Btn_Forgot_Click(object sender, RoutedEventArgs e)
        {

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
