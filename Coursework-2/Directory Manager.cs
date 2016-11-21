using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Coursework_2
{
    public class DirectoryManager //class to choose the correct file path or return null if none available are valid
    {
        private string path; //string storing the path to a persistence folder where all persistent files will be stored


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
                path = @"F:\Persistence\";
            }
            else if (Directory.Exists(@"G:\")) //drive G for USB drive at home
            {
                path = @"G:\Persistence\";
            }
            else if (!Directory.Exists(@"D:\") && !Directory.Exists(@"F:\") && !Directory.Exists(@"G:\"))//if no USB at merchiston use H drive
            {
                path = @"H:\Persistence";
            }
            else //Where are you even trying to run this?
            {
                path = null;
            }

            return path;
            
        }
    }
}
