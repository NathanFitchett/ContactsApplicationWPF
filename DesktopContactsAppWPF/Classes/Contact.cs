using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsAppWPF.Classes
{
    public class Contact
    {
        //create attribute for Primary key for contact table
        [PrimaryKey, AutoIncrement] //AutoIncrement (1,1) seed and value
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //public override string ToString()
        //{
        //    return $"{Name} - {Email} - {Phone}"; //Return values in this format for display view of listview on main window
        //}
    }
}
