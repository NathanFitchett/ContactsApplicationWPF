using DesktopContactsAppWPF.Classes;
using SQLite;
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

namespace DesktopContactsAppWPF
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
            //Have window open in center of window
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save the contact Add SQLlite from nuget
            Contact contact = new Contact()
            {
                //Access text from text box and assign 
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
                
            };

            

            //defined in App.XAML.CS class
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Pass through database path to establish connection
                connection.CreateTable<Contact>(); //Pass through type Contact with Contact Table def
                connection.Insert(contact); //Insert contact as object to pass
            }


            this.Close();//Close window
        }
    }
}
