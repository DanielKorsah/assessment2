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

namespace Coursework_2
{
    /// <summary>
    /// Interaction logic for HubPage.xaml
    /// </summary>
    public partial class HubPage : Window
    {
        public HubPage()
        {
            InitializeComponent();
        }


        private void editCustomerButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void bookingButton_Click(object sender, RoutedEventArgs e, Customer currentCustomer)
        {
            CreateBooking currentBooking = new CreateBooking(currentCustomer);
            currentBooking.Show();
        }


        private void editBookingButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
