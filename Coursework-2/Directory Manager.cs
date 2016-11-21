using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Coursework_2
{
    class DirectoryManager
    {
        private string path;


        //<validate file path>
        public string GetPath()
        {
            if (Directory.Exists(@"D:\") && !Directory.Exists(@"F:\"))//set to D drive for USB in games lab 
            {
                Directory.CreateDirectory(@"D:\Persistence");
                path = @"D:\Persistence\"; 
            }
            else if (Directory.Exists(@"F:\") && !Directory.Exists(@"G:\")) //set to F drive for USB in JKCC
            {
                path = @"F:\Persistence\Customers.txt";
            }
            else if (Directory.Exists(@"G:\")) //drive G for USB drive at home
            {
                path = @"G:\persistence\Customers.txt";
            }
            else if (!Directory.Exists(@"D:\") && !Directory.Exists(@"F:\") && !Directory.Exists(@"G:\"))//if no USB at merchiston use H drive
            {
                path = @"H:\Customers.txt";
            }
            else //Where are you even trying to run this?
            {
                path = null;
            }

            return path;
            
        }
    }
}
