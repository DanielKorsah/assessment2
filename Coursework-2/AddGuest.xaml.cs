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
using System;

namespace Coursework_2
{
    /// <summary>
    /// Interaction logic for AddGuest.xaml
    /// </summary>
    public partial class AddGuest : Window
    {
        Guest guest;
        Booking currentBooking;

        public AddGuest(ref Guest nextGuest, ref Booking currentBooking)
        {
            InitializeComponent();
            this.guest = nextGuest;
            this.currentBooking = currentBooking;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (currentBooking.GuestList.Count < 4)
            {
                if (string.IsNullOrEmpty(ppBox.Text) == false && string.IsNullOrEmpty(nameBox.Text) == false && string.IsNullOrEmpty(ageBox.Text) == false)
                {
                    guest.Passport = ppBox.Text;
                    guest.Name = nameBox.Text;
                    try { guest.Age = Int32.Parse(ageBox.Text); }
                    catch
                    {
                        MessageBox.Show("Ages are numbers not letters, wise guy.", "Invalid Input.", //show reason for error
                            MessageBoxButton.OK, MessageBoxImage.Error); //Punish their stupidity with a BONK
                    }


                    guest.Booking = currentBooking.BookingRef;
                    currentBooking.AddToList(guest);
                }
                else
                {
                    MessageBox.Show("All fields must be filled.", "Missiang data.", //show reason for error
                            MessageBoxButton.OK, MessageBoxImage.Error); //Punish their stupidity with a BONK
                }
            }
            this.Close();
        }
    }
}
