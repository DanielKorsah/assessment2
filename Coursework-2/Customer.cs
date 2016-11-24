using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    public class Customer
    {
        //contains inforamtion for each customer
        //one customer can have many bookings

        private string name; //name of person making booking
        private string address; //address of said customer
        private int customerRef; //unique identifying number for each guest starting at 1
        private List<int> custBookings = new List<int> { };
        private string stringRef;

        public string Name //name accessor
        {
            get { return name; } //allow fetching of current value of name
            set { name = value; } //allow name to be set to a new value when necessary
        }

        public string Address //address accessor - does the same as above but for address
        {
            get { return address; } 
            set { address = value; }
        }

        public int CustomerRef //customer ref accessor - does the same as name accessor and address accessor but for customerRef
        {
            get { return customerRef; }
            set { customerRef = value; }
        }

        public List<int> CustBookings
        {
            get { return custBookings; }
        }

        public Customer()
        {

        }

        public Customer(string name1, string name2, string address1, string address2, string city, string postCode) //read arguments from window to construct Customer
        {
            name = name1 + " " + name2 + ", "; //Make name a single string, extra comma for correct formatting when printed to .csv file
            address = address1 + ", " + address2 + ", " + city + ", " + postCode; //construct a singe line address from constituant parts

        }

        public void AddCustBookings(int _bookingRef)
        {
            custBookings.Add(_bookingRef);
        }
        
        
    }
}
