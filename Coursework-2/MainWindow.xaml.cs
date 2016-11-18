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
            newButton.Content = "new &#xa Customer";
           
        }

        private void newButton_Click(object sender, RoutedEventArgs e) //execute when New Customer button is clicked on GUI
        {

        }

        private void returningButton_Click(object sender, RoutedEventArgs e) //execute when Returning Customer button is clicked on GUI
        {

        }
    }
}
