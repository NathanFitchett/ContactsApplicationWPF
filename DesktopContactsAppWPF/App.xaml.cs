using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsAppWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Database path init setup 
        public static string databaseName = "Contacts.db";
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //Access my documents folder
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName); //conformed path for db to be stored
    }
}
