using System;
using System.Collections.Generic;
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

namespace LeaveRequest.View
{
    /// <summary>
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class Manage : Window
    {
        public Manage()
        {
            InitializeComponent();
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
            getHoliday();
            hideTypeLeave();
            hideLeaveStatus();
        }
        private void Btn_Type_Leave_Click(object sender, RoutedEventArgs e)
        {
            hideHoliday();
            getTypeLeave();
            hideLeaveStatus();
        }
        private void Btn_Leave_Status_Click(object sender, RoutedEventArgs e)
        {
            hideHoliday();
            hideTypeLeave();
            getLeaveStatus();
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Home home = new Home();
            home.Show();
            this.Close();
        }
        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Approver approve = new Approver();
            approve.Show();
            this.Close();
        }
        private void History_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            History history = new History();
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

    }
}
