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
using LeaveRequest.Controllers;
using LeaveRequest.Models;


namespace LeaveRequest.View
{
    /// <summary>
    /// Interaction logic for Requester.xaml
    /// </summary>
    public partial class Requester : Window
    {
        public double TotalMinutes { get; }
        public int G_Id;
        public string G_Name;
        public string G_NIK;
        public int G_lst_leave;
        public int G_crnt_leave;
        public int G_jumlah;
        public Requester(string NIK)
        {
            InitializeComponent();
            InitializeComponent();
            setNIK(NIK);
            setName(NIK);
            getSisaCuti(NIK);
            _Txt_Name.Text = "" + G_Name + "";
            Txt_Name.Text = "" + G_Name + "";
            Txt_NIK.Text = "" + G_NIK + "";
            Txt_LastYearCuti.Text = "" + G_lst_leave + "";
            Txt_CurrentCuti.Text = "" + G_crnt_leave + "";

            Type_Leave _leave = new Type_Leave();
            MyContext _context = new MyContext();

            //var get = _context.Type_Leaves.Where(u => u.isDeleted != true).ToList();
            //comboBox.ItemsSource = get;
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
        public void getSisaCuti(string NIK)
        {
            MyContext _context = new MyContext();
            var get = _context.Employees.Find(NIK);
            int crnt_leave = get.Current_Leave_Request;
            int lst_leave = get.Last_Year_Request;
            G_crnt_leave = crnt_leave;
            G_lst_leave = lst_leave;
        }
        private void History_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Request_Controller _request = new Request_Controller();

            //MessageBox.Show("");
            DateTime sDate = Convert.ToDateTime(StartDate.Text);
            DateTime eDate = Convert.ToDateTime(EndDate.Text);
            if (G_crnt_leave < 0)
            {
                MessageBox.Show("Leave Not Enough!");
            }
            else
            {
                _request.addRequest(G_NIK, sDate, eDate, G_crnt_leave, G_lst_leave);
            }
            //string s = comboBox.Text;
            //MessageBox.Show("" + s + "");
        }

        private void Changed(object sender, SelectionChangedEventArgs e)
        {
            DateTime sDate = Convert.ToDateTime(StartDate.Text);
            DateTime eDate = Convert.ToDateTime(EndDate.Text);
           
            string total = eDate.Subtract(sDate).Days.ToString();
            int days = Convert.ToInt32(total);
            G_jumlah = days + 1;
            if(G_jumlah > 5)
            {
                MessageBox.Show("Cannot Request More Than 5 Days!");
            }
            else
            {
                if (G_jumlah < G_lst_leave)
                {
                    G_lst_leave -= G_jumlah;
                }
                else
                {
                    int temp = G_jumlah - G_lst_leave;
                    G_crnt_leave -= temp;
                    G_lst_leave = 0;
                }
                
                Txt_JumlahCuti.Text = "" + G_jumlah + "";
                Txt_LastYearCuti.Text = "" + G_lst_leave + "";
                Txt_CurrentCuti.Text = "" + G_crnt_leave + "";
            }
            
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Home home = new Home(G_NIK);
            home.Show();
            this.Close();
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Manage manage = new Manage(G_NIK);
            manage.Show();
            this.Close();
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Approver Approver = new Approver(G_NIK);
            Approver.Show();
            this.Close();
        }
    }
}
