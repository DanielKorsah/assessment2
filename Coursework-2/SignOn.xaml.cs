﻿using System;
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

            if (string.IsNullOrEmpty(name1) == false && string.IsNullOrEmpty(name2) == false && string.IsNullOrEmpty(address1) == false  && string.IsNullOrEmpty(city) == false && string.IsNullOrEmpty(postCode) == false)
            {
                Customer currentCustomer = new Customer(name1, name2, address1, address2, city, postCode); //pass Customer details to Customer constructor
                UserTracker tracker = UserTracker.Instance; //return the only instance of UserTracker

                tracker.IncrementCount();
                tracker.Store(currentCustomer);
                MessageBox.Show("Your Customer reference number is " + currentCustomer.CustomerRef + ".\nYou will need this every time you log in."); //tell customer their ref number

                HubPage hub = new HubPage(currentCustomer);
                if (tracker._Path != null) //if the details were successfully printed to the a valid file path
                {
                    hub.Show(); //on with the show go to the hub page
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("All compulsory fields (*) must be filled.", "Missing data.", // reason for error
                     MessageBoxButton.OK, MessageBoxImage.Error); //give 'em a BONK 
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow startPage = new MainWindow();
            startPage.Show();
            this.Close();
        }
    }
}
