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
    /// Interaction logic for delGuest.xaml
    /// </summary>
    public partial class delGuest : Window
    {
        Booking currentBooking;

        public delGuest(ref Booking currentBooking)
        {
            InitializeComponent();
            this.currentBooking = currentBooking;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            string passNum = delBox.Text;
            GuestTracker del = GuestTracker.Instance;
            del.Delete(currentBooking, passNum);
        }
    }
}
