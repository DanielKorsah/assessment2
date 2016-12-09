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
    /// Interaction logic for EditBooking.xaml
    /// </summary>
    public partial class EditBooking : Window
    {
        private Customer customer;

        public EditBooking(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            bookingListLable.Content = bookingListLable.Content + " " + String.Join(", ", customer.CustBookings);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage(customer);
            hub.Show();
            this.Close();
        }
    }
}
