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
using LeaveRequest.Models;
using LeaveRequest.Controllers;


namespace LeaveRequest.View
{
    /// <summary>
    /// Interaction logic for Approver.xaml
    /// </summary>
    public partial class Approver : Window
    {
        

        public string G_NIK;
        public Approver(string NIK)
        {
            MyContext _context = new MyContext();

            InitializeComponent();
            setNIK(NIK);
            
             var get = _context.TR_Leaves.Join(_context.Leave_Datas, p => p.Leave_Data_Id, s => s.Id, (p, s) => new
                {
                    Id = p.Id,
                    _name = s.Name,
                    sDate = s.StartDate,
                    eDate = s.EndDate,
                    type = s.Type_Leave_ID,
                    status = p.Leave_Status_Id,
                    _nik = s.NIK,
                    _mng = s.Manager_Id
                }).Where(u => u._mng == G_NIK).ToList();
            DataGridApprover.ItemsSource = get;
        }
        public void setNIK(string NIK)
        {
            G_NIK = NIK;
        }

        private void Btn_Approved_Click(object sender, RoutedEventArgs e)
        {
            MyContext _context = new MyContext();
            Leave_Data _leave = new Leave_Data();

            var get = _context.Leave_Datas.Max(u=>u.Id);
            MessageBox.Show("" + get + "");
        }

        private void Btn_Rejected_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(G_NIK);

            this.Hide();
            home.Show();
            this.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(G_NIK);

            this.Hide();
            home.Show();
            this.Close();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            History history = new History(G_NIK);

            this.Hide();
            history.Show();
            this.Close();
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            Manage manage = new Manage(G_NIK);

            this.Hide();
            manage.Show();
            this.Close();
        }
    }
}
