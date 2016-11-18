using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    class Customer
    {
        //contains inforamtion for each customer
        //one customer can have many bookings

        private string name; //name of person making booking
        private string address; //address of said customer
        private int customerRef; //unique identifying number for each guest

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
        
    }
}
