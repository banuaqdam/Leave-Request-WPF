using LeaveRequest.Models;
using LeaveRequest.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LeaveRequest.Controllers;

namespace LeaveRequest.View
{
    /// <summary>
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class Manage : Window
    {
        public string G_NIK;
        private object item;
        public Manage(string NIK)
        {
            InitializeComponent();
            setNIK(NIK);
        }
        public void setNIK(string NIK)
        {
            G_NIK = NIK;
        }
        private void getHoliday()
        {
            DataGridHoliday.Visibility = Visibility.Visible;
            txtHoliday.Visibility = Visibility.Visible;
            getStartDate.Visibility = Visibility.Visible;
            getEndDate.Visibility = Visibility.Visible;
            Btn_Save_Holiday.Visibility = Visibility.Visible;
        }
        private void hideHoliday()
        {
            DataGridHoliday.Visibility = Visibility.Hidden;
            txtHoliday.Visibility = Visibility.Hidden;
            getStartDate.Visibility = Visibility.Hidden;
            getEndDate.Visibility = Visibility.Hidden;
            Btn_Save_Holiday.Visibility = Visibility.Hidden;
            txtHoliday.Clear();
            getStartDate.Text = "";
            getEndDate.Text = "";            
        }
        private void getTypeLeave()
        {
            DataGridTypeLeave.Visibility = Visibility.Visible;
            txtTypeLeave.Visibility = Visibility.Visible;
            txtDuration.Visibility = Visibility.Visible;
            Btn_Save_Type_Leave.Visibility = Visibility.Visible;
        }
        private void hideTypeLeave()
        {
            DataGridTypeLeave.Visibility = Visibility.Hidden;
            txtTypeLeave.Visibility = Visibility.Hidden;
            txtDuration.Visibility = Visibility.Hidden;
            Btn_Save_Type_Leave.Visibility = Visibility.Hidden;
            txtTypeLeave.Clear();
            txtDuration.Clear();
        }
        private void getLeaveStatus()
        {
            DataGridLeaveStatus.Visibility = Visibility.Visible;
            txtStatus.Visibility = Visibility.Visible;
            Btn_Save_Leave_Status.Visibility = Visibility.Visible;
        }
        private void hideLeaveStatus()
        {
            DataGridLeaveStatus.Visibility = Visibility.Hidden;
            txtStatus.Visibility = Visibility.Hidden;
            Btn_Save_Leave_Status.Visibility = Visibility.Hidden;
            txtStatus.Clear();
        }
        private void Btn_Holiday_Click(object sender, RoutedEventArgs e)
        {
            hideTypeLeave();
            hideLeaveStatus();
            getHoliday();
            Btn_Holiday.IsEnabled = false;
            Btn_Leave_Status.IsEnabled = true;
            Btn_Type_Leave.IsEnabled = true;

            Holiday _holiday = new Holiday();
            MyContext _context = new MyContext();

            var get = _context.Holidays.Where(u => u.isDeleted != true).ToList();
            DataGridHoliday.ItemsSource = get;
        }
        private void Btn_Type_Leave_Click(object sender, RoutedEventArgs e)
        {
            hideHoliday();
            hideLeaveStatus();
            getTypeLeave();
            Btn_Type_Leave.IsEnabled = false;
            Btn_Holiday.IsEnabled = true;
            Btn_Leave_Status.IsEnabled = true;

            Type_Leave types = new Type_Leave();
            MyContext _context = new MyContext();

            var get = _context.Type_Leaves.Where(u => u.isDeleted != true).ToList();
            DataGridTypeLeave.ItemsSource = get;

        }
        private void Btn_Leave_Status_Click(object sender, RoutedEventArgs e)
        {
            hideHoliday();
            hideTypeLeave();
            getLeaveStatus();
            Btn_Leave_Status.IsEnabled = false;
            Btn_Type_Leave.IsEnabled = true;
            Btn_Holiday.IsEnabled = true;

            Leave_Status types = new Leave_Status();
            MyContext _context = new MyContext();

            var get = _context.Leave_Status.Where(u => u.isDeleted != true).ToList();
            DataGridLeaveStatus.ItemsSource = get;
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
        private void History_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            History history = new History(G_NIK);
            history.Show();
            this.Close();
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Type_Save(object sender, RoutedEventArgs e)
        {
            MyContext _context = new MyContext();
            Type_Leave _type = new Type_Leave();

            var result = 0;
            string name = txtTypeLeave.Text;
            int _duration = Convert.ToInt32(txtDuration.Text);

            _type.Name = name;
            _type.Duration = _duration;
            _type.isDeleted = false;

            _context.Type_Leaves.Add(_type);
            result = _context.SaveChanges();
            if (result > 0)
            {
                MessageBox.Show("Berhasil");
                var get = _context.Type_Leaves.Where(u => u.isDeleted != true).ToList();
                DataGridTypeLeave.ItemsSource = get;
            }
            else
            {
                MessageBox.Show("Gagal!");
            }
        }

        private void TypeSelectedCell(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataGridTypeLeave.SelectedCells != null)
            {
                item = DataGridTypeLeave.SelectedItem;

                txtTypeLeave.Text = (DataGridTypeLeave.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                txtDuration.Text = (DataGridTypeLeave.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;      
                //TypeVar((DataGridTypeLeave.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text, (DataGridTypeLeave.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            }
        }
        private void StatusSelectedCell(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataGridLeaveStatus.SelectedCells != null)
            {
                item = DataGridLeaveStatus.SelectedItem;

                txtStatus.Text = (DataGridLeaveStatus.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                //TypeVar((DataGridTypeLeave.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text, (DataGridTypeLeave.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            }
        }
        private void HolidaySelectedCell(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataGridHoliday.SelectedCells != null)
            {
                item = DataGridHoliday.SelectedItem;

                txtHoliday.Text = (DataGridHoliday.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                getStartDate.Text = (DataGridHoliday.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                getEndDate.Text = (DataGridHoliday.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                //TypeVar((DataGridTypeLeave.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text, (DataGridTypeLeave.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            }
        }
        public void TypeVar (string _name,string _duration)
        {
            
        }

        private void Btn_Del_Type_Leave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this record?", "Delete Warning!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ManageData _manage = new ManageData();

                _manage.DeleteTypeLeave(Convert.ToInt16((DataGridTypeLeave.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
            }
            else
            {
                MessageBox.Show("Delete Record Successfully Canceled!");
            }
        }

        private void SelectedCell(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void Btn_Update_Type_Leave_Click(object sender, RoutedEventArgs e)
        {
            ManageData _manage = new ManageData();

            if (txtTypeLeave.Text.Length == 0 && txtDuration.Text.Length == 0)
            {
                MessageBox.Show("You Must Enter Type Name & Duration!");
            }
            else if (txtTypeLeave.Text.Length == 0 )
            {
                MessageBox.Show("You Must Enter Type Name!");
            }
            else if(txtDuration.Text.Length == 0)
            {
                MessageBox.Show("You Must Enter Duration!");
            }
            else
            {
                string _name = txtTypeLeave.Text;
                int _duration = Convert.ToInt32(txtDuration.Text);

                _manage.Update_TypeLeave(Convert.ToInt16((DataGridTypeLeave.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), _name, _duration);
            }
        }

        private void Btn_Update_Holiday_Click(object sender, RoutedEventArgs e)
        {
            ManageData _manage = new ManageData();

            if (txtHoliday.Text.Length != 0 && getStartDate.Text.Length != 0 && getEndDate.Text.Length != 0)
            {
                string _name = txtTypeLeave.Text;
                DateTime sDate = Convert.ToDateTime(getStartDate.Text);
                DateTime eDate = Convert.ToDateTime(getEndDate.Text);

                _manage.Update_Holiday(Convert.ToInt16((DataGridTypeLeave.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), _name, sDate,eDate);
            }
            else
            {
                MessageBox.Show("Please Fill All DATA!");
            }
        }

        private void Btn_Del_Holiday_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this record?", "Delete Warning!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ManageData _manage = new ManageData();

                _manage.DeleteTypeLeave(Convert.ToInt16((DataGridTypeLeave.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
            }
            else
            {
                MessageBox.Show("Delete Record Successfully Canceled!");
            }
        }

        private void Btn_Save_Holiday_Click(object sender, RoutedEventArgs e)
        {
            ManageData _manage = new ManageData();


            if (txtHoliday.Text.Length != 0 && getStartDate.Text.Length != 0 && getEndDate.Text.Length != 0)
            {
                Holiday _holiday = new Holiday();
                MyContext _context = new MyContext();

                string name = txtHoliday.Text;
                DateTime sDate = Convert.ToDateTime(getStartDate.Text);
                DateTime eDate = Convert.ToDateTime(getEndDate.Text);

                _manage.addHoliday(name, sDate, eDate);
                var get = _context.Holidays.Where(u => u.isDeleted != true).ToList();
                DataGridHoliday.ItemsSource = get;
            }
            else
            {
                MessageBox.Show("Please Fill All Data!");
            }
        }
    }
}
