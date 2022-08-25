using DesktopContactsAppWPF.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            //instantiate 
            contacts = new List<Contact>();
            //Read Data
            ReadDataBase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //create instance of window
            NewContactWindow newContactWindow = new NewContactWindow();
            //show dialog so prev window can't be accessed until new window is closed
            newContactWindow.ShowDialog();
            //Read data
            ReadDataBase();
        }

        void ReadDataBase()
        {
            

            //Establish connection to db
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>(); //Define table
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList(); //Retreive table ToList get querey  and order alphabetically
            };

            //If not null populate list view
            if(contacts != null)
            {
                //set source to contacts to display elements in list
                contactsListView.ItemsSource = contacts;
            }
        }

        //Have user filter by name method
        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            //Filter results with what user has written in textbox
            //evauluate where their name contains whatever the user has written
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            /*
            //SQL format
            var filteredList = (from c2 in contacts
                               where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                               orderby c2.Email
                               select c2).ToList();
            */

            contactsListView.ItemsSource = filteredList;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if(selectedContact != null)
            {
                //create instance of window pass selectedcontact value
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                //show dialog so prev window can't be accessed until new window is closed
                contactDetailsWindow.ShowDialog();
                //Update
                ReadDataBase();
            }
        }
    }
}
