using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Coursework_2
{
    public class DirectoryManager // Singleton - class to choose the correct file path or return null if none available are valid
    {
        private string path; //string storing the path to a persistence folder where all persistent files will be stored

        //<make it a singleton>
        private static DirectoryManager instance; //only reference to Directorymanager object
        private DirectoryManager() { } //set to private so it can't be called

        public static DirectoryManager Instance
        {
            get
            {
                if (instance == null) //if this is the first call (i.e. instance is not null)
                {
                    instance = new UserTracker(); //instanciate the object
                }
                return instance; //else return instance (null)
            }
        }
        //</make it a singleton>

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
            //</validate file path>

            return path; //return the correct path if a valid one exists, if validation fails return null
            
        }
    }
}
