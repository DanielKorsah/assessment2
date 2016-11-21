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
    /// Interaction logic for SignOn.xaml
    /// </summary>
    public partial class SignOn : Window
    {
        public SignOn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //<take strings from UI>
            string name1 = nameBox.Text;
            string name2 = nameBox2.Text;
            string address1 = addressBox1.Text;
            string address2 = addressBox2.Text;
            string city = addressBox3.Text;
            string postCode = addressBox4.Text;
            //</take strings from UI>

            Customer currentCustomer = new Customer(name1, name2, address1, address2, city, postCode); //pass Customer details to Customer constructor
            UserTracker tracker = UserTracker.Instance; //return the only instance of UserTracker

            tracker.Store(currentCustomer);

            CreateBooking createBooking = new CreateBooking(currentCustomer);
            if (tracker._Path != null) //if the details were successfully printed to the a valid file path
            {
                createBooking.Show(); //on with the show, start making a booking
            }
        }
    }
}
