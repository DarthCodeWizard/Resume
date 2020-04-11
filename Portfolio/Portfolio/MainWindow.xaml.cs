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

namespace Portfolio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> people = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateBinding();
        }
        private void UpdateBinding()
        {
            PeopleFound.DataContext = people;
            PeopleFound.DisplayMemberPath = "FullInfo";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Minimalize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAcces db = new DataAcces();
                if (FirstNameContent.Text != "")
                {
                    people = db.GetPeople(FirstNameContent.Text);
                }
                else if (LastNameContent.Text != "")
                {
                    people = db.GetPeople(LastNameContent.Text);
                }
                else if (JobContent.Text != "")
                {
                    people = db.GetPeople(JobContent.Text);
                }
                else if (PhoneContent.Text != "")
                {
                    people = db.GetPeople(PhoneContent.Text);
                }
                else if (EmailContent.Text != "")
                {
                    people = db.GetPeople(EmailContent.Text);
                }
                else if ((FirstNameContent.Text != "") && (LastNameContent.Text != "") && (JobContent.Text != "") && (PhoneContent.Text != "") && (EmailContent.Text != ""))
                {
                    people = db.GetALLPeople(FirstNameContent.Text, LastNameContent.Text, JobContent.Text, PhoneContent.Text, EmailContent.Text);
                }


                UpdateBinding();

                FirstNameContent.Text = "";
                LastNameContent.Text = "";
                JobContent.Text = "";
                PhoneContent.Text = "";
                EmailContent.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
           
            
                foreach (Person removedItem in PeopleFound.SelectedItems)
                {
                    (PeopleFound.ItemsSource as List<Person>).Remove(removedItem);
                }
                PeopleFound.Items.Refresh();
           
        }

        private void ListAllButton_Click(object sender, RoutedEventArgs e)
        {
            
                DataAcces db = new DataAcces();
                people = db.ListAll();
                UpdateBinding();
           
        }

        private void UpdateButon_Click(object sender, RoutedEventArgs e)
        {
           
                DataAcces db = new DataAcces();
                db.Insert(FirstNameContent.Text, LastNameContent.Text, JobContent.Text, PhoneContent.Text, EmailContent.Text);
                FirstNameContent.Text = "";
                LastNameContent.Text = "";
                JobContent.Text = "";
                PhoneContent.Text = "";
                EmailContent.Text = "";
            
        }
    }
}
