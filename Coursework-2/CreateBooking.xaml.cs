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
    /// Interaction logic for CreateBooking.xaml
    /// </summary>
    public partial class CreateBooking : Window
    {
        Customer workingCustomer = null;
        public CreateBooking(Customer hubCust)
        {
            InitializeComponent();
            workingCustomer = hubCust;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string temp = inDatePick.Text;
            label.Content = temp;
        }
    }
}
