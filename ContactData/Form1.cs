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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Button Add = sender as Button;

            //Adding a new item to the server
            using (var context = new PeopleEntities())
            {
                var newperson = new People
                {
                    FirstName = textBox1.Text,
                    LastName = textBox2.Text,
                    PhoneNumber = int.Parse(PhoneNumberTxt.Text)
                };
                context.People.Add(newperson);
                context.SaveChanges();
            }
            //clears the boxes
            textBox1.Clear();
            textBox2.Clear();
            PhoneNumberTxt.Clear();
            MessageBox.Show("Användare inlaggd");

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
