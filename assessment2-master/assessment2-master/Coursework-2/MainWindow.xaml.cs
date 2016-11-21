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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void newButton_Click(object sender, RoutedEventArgs e) //open sign on paghe when New Customer button is clicked on GUI
        {
            SignOn signOnPage = new SignOn(); 
            signOnPage.Show(); 
        }

        private void returningButton_Click(object sender, RoutedEventArgs e) //open log in page when Returning Customer button is clicked on GUI
        {
            LogIn logInPage = new LogIn();
            logInPage.Show();
        }


    }
}
