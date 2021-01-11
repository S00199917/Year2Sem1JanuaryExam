using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Year2Sem1JanuaryExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creates different lists
        static ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        static ObservableCollection<CurrentAccount> currents = new ObservableCollection<CurrentAccount>();
        static ObservableCollection<SavingsAccount> savings = new ObservableCollection<SavingsAccount>();

        public MainWindow()
        {
            InitializeComponent();

            //Creates two objects of type Savings account
            SavingsAccount savings0 = new SavingsAccount("Cave", "Johnson", 15000m, 22);
            SavingsAccount savings1 = new SavingsAccount("Frank", "Conway", 11254m, 113);

            //Adds to the savings list
            savings.Add(savings0);
            savings.Add(savings1);

            //creates two objects of type current account
            CurrentAccount current = new CurrentAccount("Jimmy", "Money", 5512m, 42);
            CurrentAccount current1 = new CurrentAccount("John", "Doe", 552132m, 551);

            //adds to the currents account
            currents.Add(current);
            currents.Add(current1);

            //adds to the accounts list
            accounts.Add(savings0);
            accounts.Add(savings1);
            accounts.Add(current);
            accounts.Add(current1);

            //adds the list to the list box
            lstbxAccounts.ItemsSource = accounts;
        }

        private void chbxSavingsAccounts_Click(object sender, RoutedEventArgs e)
        {
            //removes all items from the list box
            lstbxAccounts.ItemsSource = null;

            //checks if the current accounts check box isn't checked and if the savings account is checked
            if (chbxCurrentAccounts.IsChecked == false && chbxSavingsAccounts.IsChecked == true)
            {
                //adds only the savings list to the list box
                lstbxAccounts.ItemsSource = savings;
            }
            //checks for the reverse
            else if (chbxCurrentAccounts.IsChecked == true && chbxSavingsAccounts.IsChecked == false)
            {
                //adds only the currents list to the list box
                lstbxAccounts.ItemsSource = currents;
            }
            //checks if none or both of the check boxes have been checked
            else
            {
                //adds the accounts list to the list box
                lstbxAccounts.ItemsSource = accounts;
            }
        }

        private void chbxCurrentAccounts_Click(object sender, RoutedEventArgs e)
        {
            //removes all of the items from the list box
            lstbxAccounts.ItemsSource = null;

            //checks if the savings account check box isn't checked and if the current accounts check box is
            if (chbxSavingsAccounts.IsChecked == false && chbxCurrentAccounts.IsChecked == true)
            {
                //adds only the currents list to the list box
                lstbxAccounts.ItemsSource = currents;
            }
            //checks the reveres
            else if (chbxSavingsAccounts.IsChecked == true && chbxCurrentAccounts.IsChecked == false)
            {
                //Adds only the savings list to the list box
                lstbxAccounts.ItemsSource = savings;
            }
            //checks if none or both of the check boxes have been checked
            else
            {
                //adds the accounts list to the list box
                lstbxAccounts.ItemsSource = accounts;
            }
        }

        private void lstbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //creates an object of type account from the selected item from the list box
            Account account = lstbxAccounts.SelectedItem as Account;

            //checks if the user selected an account that isn't null
            if (account != null)
            {
                //shows the accounts first name
                tblkFirstName.Text = account.FirstName;
                //shows the accounts surname
                tblkSurname.Text = account.LastName;
                //shows the accounts balance
                tblkBalance.Text = account.Balance.ToString();
                //shows the account type
                tblkAccountType.Text = account.AccountType;
                //shows when the interest was last applied
                tblkIntrerestDate.Text = account.InterestDate.ToString("d");
            }
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            //creates a temperary decimal variable
            decimal tempDecimal;

            //creates an object of type account form the selected item from the list box
            Account account = lstbxAccounts.SelectedItem as Account;

            //checks if the selected account is null
            if (account != null)
            {
                //checks if the text that has been added to the text box is of type decimal and assings it to tempDeciaml
                if (decimal.TryParse(tbxTransactionAmount.Text, out tempDecimal) == true)
                {
                    //Checks if the value is greater than zero
                    if (tempDecimal > 0)
                    {
                        //Adds the amount to the balance
                        account.Balance += tempDecimal;
                    }
                    //if the value is less than or equal to zero, this code runs
                    else
                    {
                        //tells the user that the number must be greater than 0
                        MessageBox.Show("Number must be greater than 0");
                    }
                }
                //tells the user that it was an invalid input
                else
                {
                    MessageBox.Show("Invalid input");
                }
            }

        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            //creates a temperary decimal variable
            decimal tempDecimal;

            //creates an object of type account from the selected account from the list box
            Account account = lstbxAccounts.SelectedItem as Account;

            //checks if the account is not null
            if (account != null)
            {
                //checks if the user entered a decimal and then assings it to temp decimal
                if (decimal.TryParse(tbxTransactionAmount.Text, out tempDecimal) == true)
                {
                    //checks if the user entered a number less than zero
                    if (tempDecimal < 0)
                    {
                        account.Balance += tempDecimal;
                    }
                    else
                    {
                        MessageBox.Show("Number must be greater than 0");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input");
                }
            }
            else
            {
                MessageBox.Show("A decimal value must be added to the Transaction Account text box");
            }
        }

        private void btnInterest_Click(object sender, RoutedEventArgs e)
        {
            //creates an object of type date time
            DateTime today = new DateTime();
            //gives the object a date and time of now
            today = DateTime.Now;

            Account account = lstbxAccounts.SelectedItem as Account;

            if (account != null)
            {
                account.CalculateInterest();
                account.InterestDate = DateTime.Now;
            }

        }
    }
}