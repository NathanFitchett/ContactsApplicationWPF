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
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;
            //Show values selected in this new window
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;

            //Have window open in center of window
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //Set values before update 
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;


            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Pass through database path to establish connection
                connection.CreateTable<Contact>(); //Pass through type Contact with Contact Table def
                connection.Update(contact); //Update contact as object to pass
            }


            this.Close();//Close window
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //defined in App.XAML.CS class
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Pass through database path to establish connection
                connection.CreateTable<Contact>(); //Pass through type Contact with Contact Table def
                connection.Delete(contact); //Delete contact as object to pass
            }


            this.Close();//Close window
        }
    }
}
