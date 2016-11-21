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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string checkNum = custRefBox.Text.Trim(); //checknum = user's input. .Trim() added to remove line feed characters
            Customer currentCustomer = new Customer(); 
            UserTracker tracker = UserTracker.Instance; //singleton instance of UserTracker

            tracker.CheckCustId(checkNum, currentCustomer); 

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow startPage = new MainWindow();
            startPage.Show();
            this.Close();
        }
    }
}
