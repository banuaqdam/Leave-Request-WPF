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
            TR_Leave _tr = new TR_Leave();
            MyContext _context = new MyContext();
            Leave_Data _data = new Leave_Data();

            var get = _context.TR_Leaves.Join(_context.Leave_Datas, p => p.Leave_Data_Id, s => s.Id, (p, s) => new
            {
                Id = p.Id,
                sDate = s.StartDate,
                eDate = s.EndDate,
                type = s.Type_Leave_ID,
                status = p.Leave_Status_Id,
                 _nik = s.NIK
            }).Where(u => u._nik == G_NIK).ToList();
            DataGridHistory.ItemsSource = get;
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
