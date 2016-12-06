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
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;

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

            //split first and second name and set them to the corresponding text boxes for unedited values
            string[] name= Regex.Split(editCustomer.Name, " ");
            nameBox1.Text = name[0];
            nameBox2.Text = Regex.Split(editCustomer.Name, " ")[1];

            //split up address between seperate boxed for unedited values
            addressBox1.Text = Regex.Split(editCustomer.Address, " ")[0];
            addressBox2.Text = Regex.Split(editCustomer.Address, " ")[1];
            cityBox.Text = Regex.Split(editCustomer.Address, " ")[2];
            postBox.Text = Regex.Split(editCustomer.Address, " ")[3];
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            HubPage hub = new HubPage(editCustomer);
            hub.Show();
            this.Close();
        }

        protected virtual void OnLoad(EventArgs e)
        {
            
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //<set new name and address>
            editCustomer.Name = nameBox1.Text + " " + nameBox2.Text;
            editCustomer.Address = addressBox1.Text + " " + addressBox2.Text + " " + cityBox.Text + " " + postBox.Text;
            //</set new name and address>
        }
    }
}
