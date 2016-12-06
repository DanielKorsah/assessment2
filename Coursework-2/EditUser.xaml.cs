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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private Customer editCustomer;

        public EditUser(Customer currentCustomer)
        {
            InitializeComponent();
            editCustomer = currentCustomer;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage(editCustomer);
            hub.Show();
            this.Close();
        }
    }
}
