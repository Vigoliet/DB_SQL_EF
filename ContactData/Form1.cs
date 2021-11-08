using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var MyContacts = new PeopleEntities().People;

            foreach (var item in MyContacts)
            {
                listBox1.Items.Add(item);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox Persons = sender as ListBox;
            People SelectedPerson = Persons.SelectedItem as People;
            //MessageBox.Show("Test");

            PhoneNumber.Text = $"Phonenumber: {SelectedPerson.PhoneNumber}";
            ID.Text = $"ID of Contact: {SelectedPerson.Id}";
        }
    }
    public partial class People
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
