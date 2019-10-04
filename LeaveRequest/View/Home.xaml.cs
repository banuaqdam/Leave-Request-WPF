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
using LeaveRequest.Context;

namespace LeaveRequest.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public string G_Name;
        public string G_NIK;
        public Home(string NIK)
        {
            InitializeComponent();
            setNIK(NIK);
            setName(NIK);
            Txt_Name.Text = "" + G_Name + "";
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
            G_Name = FName + " " + LName;
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            History history = new History(G_NIK);
            history.Show();
            this.Close();
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Manage Manage = new Manage(G_NIK);
            Manage.Show();
            this.Close();
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Approver Approver = new Approver(G_NIK);
            Approver.Show();
            this.Close();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            Requester request = new Requester(G_NIK);
            this.Hide();
            request.Show();
            this.Close();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            Change_Password _change = new Change_Password(G_NIK);
            this.Hide();
            _change.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logout Successful");

            this.Hide();
            Login login = new Login();
            login.Show();
            this.Close();
        }
        //private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonOpenMenu.Visibility = Visibility.Collapsed;
        //    ButtonCloseMenu.Visibility = Visibility.Visible;

        //}
        //private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonOpenMenu.Visibility = Visibility.Visible;
        //    ButtonCloseMenu.Visibility = Visibility.Collapsed;
        //}
    }
}
