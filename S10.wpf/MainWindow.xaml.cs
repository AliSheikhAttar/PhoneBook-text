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
using S10.lib;
using Microsoft.Win32;
using System.IO;
namespace S10.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        PhoneBook n;
        public MainWindow()
        {
           InitializeComponent();
            n = new PhoneBook();
            book.Text = "PhoneBook appears here :\n";
        }
        private void Add(object sender, RoutedEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(user_fname.Text)||string.IsNullOrWhiteSpace(user_lname.Text))
            {
                MessageBox.Show("No name entered. ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(user_number.Text))
            {
                MessageBox.Show("No phone number entered. ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(user_email.Text))
            {
                MessageBox.Show("No E-mail entered. ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(user_state.Text))
            {
                MessageBox.Show("No State entered. ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(user_town.Text))
            {
                MessageBox.Show("No Town entered. ");
                return;
            }
            else if (string.IsNullOrWhiteSpace(user_street.Text))
            {
                MessageBox.Show("No Street entered. ");
                return;
            }
            else
            {
                string line = $"\n{user_fname.Text} ,{user_lname.Text} ,{user_number.Text} ,{user_email.Text} ,{user_state.Text} ,{user_town.Text} ,{user_street.Text}";
                if(!book.Text.Contains(line))
                {
                    address na = new address(user_state.Text, user_town.Text, user_street.Text);
                    book.Text += line;
                    Name nn = new Name(user_fname.Text,user_lname.Text);
                    Person np =new Person(nn, user_number.Text,user_email.Text,na);
                    n.Add_to_phonebook(np);
                }
                else
                    MessageBox.Show("This has already been saved");
            }
 
        }
        public void Save(object sender,RoutedEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(File_Address.Text))
                MessageBox.Show("Please choose a file before saving.");
            else
                n.Save(File_Address.Text);
                MessageBox.Show("done");
                book.Text = string.Empty;
        }
        public void Load(object sender,RoutedEventArgs args)
        {
                if (string.IsNullOrWhiteSpace(File_Address.Text) || !File.Exists(File_Address.Text))
                    MessageBox.Show("Please choose a file before saving.");
                else
                {
                    n = PhoneBook.Load(File_Address.Text);
                    this.resetview();

                }
        }
        private void Find(object sender, RoutedEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(user_fname.Text) && 
                string.IsNullOrWhiteSpace(user_lname.Text) &&
                string.IsNullOrWhiteSpace(user_number.Text))
            {
                MessageBox.Show("No Name or Number to find");
                return;
            }

            int? number = null;
            string firstName = user_fname.Text;
            string lastName = user_lname.Text;

            if (int.TryParse(user_number.Text, out int number_out))
                number = number_out;
            
            Person f;
            if (n.Search(firstName, lastName, number, out f))
            {
                user_fname.Text = f.person_name.FirstName;
                user_lname.Text = f.person_name.LastName;
                user_number.Text = f.person_number;
                user_email.Text = f.person_email;
                user_town.Text = f.person_address.Town;
                user_state.Text = f.person_address.State;
                user_street.Text = f.person_address.Street;
            }
            else
            {
                MessageBox.Show($"Contact was Not Found");
            }
        }
        private void Delete(object sender, RoutedEventArgs args)
        {
            string number = user_number.Text;
            if(string.IsNullOrWhiteSpace(user_number.Text))
            {
                MessageBox.Show("Please enter the number of the Contact you want to delete");
                return;
            }
            if(n.Delete_contact(number))
            {
                MessageBox.Show("Contact deleted");
                this.resetview();
            }
            else
            {
                MessageBox.Show("No contact was found with such number");
            }
        }
        private void resetview()
        {
            book.Text = string.Empty;
            foreach(Person P in n._Contacts)
            {
                book.Text += $"{P.person_name.FirstName} , {P.person_name.LastName} , {P.person_number} , {P.person_email} , {P.person_address.Fulladdress}\n";
            }
        }
        private void FileDialog(object sender,RoutedEventArgs args)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog()==true)
            File_Address.Text = openFileDialog.FileName;
        }

        
    }
}
