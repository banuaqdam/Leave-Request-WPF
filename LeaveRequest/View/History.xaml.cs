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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public string G_NIK;
        public History(string NIK)
        {
            InitializeComponent();
            setNIK(NIK);
        }
        public void setNIK(string NIK)
        {
            G_NIK = NIK;
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Home home = new Home(G_NIK);
            home.Show();
            this.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Home home = new Home(G_NIK);
            home.Show();
            this.Close();
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Approver approve = new Approver(G_NIK);
            approve.Show();
            this.Close();
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Manage manage = new Manage(G_NIK);
            manage.Show();
            this.Close();
        }
    }
}
