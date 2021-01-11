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
        static ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        static ObservableCollection<CurrentAccount> currents = new ObservableCollection<CurrentAccount>();
        static ObservableCollection<SavingsAccount> savings = new ObservableCollection<SavingsAccount>();

        public MainWindow()
        {
            InitializeComponent();

            SavingsAccount savings0 = new SavingsAccount("Cave", "Johnson", 15000m, 22);
            SavingsAccount savings1 = new SavingsAccount("Frank", "Conway", 11254m, 113);

            savings.Add(savings0);
            savings.Add(savings1);

            CurrentAccount current = new CurrentAccount("Jimmy", "Money", 5512m, 42);
            CurrentAccount current1 = new CurrentAccount("John", "Doe", 552132m, 551);

            currents.Add(current);
            currents.Add(current1);

            accounts.Add(savings0);
            accounts.Add(savings1);
            accounts.Add(current);
            accounts.Add(current1);

            lstbxAccounts.ItemsSource = accounts;
        }

        private void chbxSavingsAccounts_Click(object sender, RoutedEventArgs e)
        {
            lstbxAccounts.ItemsSource = null;

            if (chbxCurrentAccounts.IsChecked == false && chbxSavingsAccounts.IsChecked == true)
            {
                lstbxAccounts.ItemsSource = savings;
            }
            else if (chbxCurrentAccounts.IsChecked == true && chbxSavingsAccounts.IsChecked == false)
            {
                lstbxAccounts.ItemsSource = currents;
            }
            else
            {
                lstbxAccounts.ItemsSource = accounts;
            }
        }

        private void chbxCurrentAccounts_Click(object sender, RoutedEventArgs e)
        {
            lstbxAccounts.ItemsSource = null;

            if (chbxSavingsAccounts.IsChecked == false && chbxCurrentAccounts.IsChecked == true)
            {
                lstbxAccounts.ItemsSource = currents;
            }
            else if (chbxSavingsAccounts.IsChecked == true && chbxCurrentAccounts.IsChecked == false)
            {
                lstbxAccounts.ItemsSource = savings;
            }
            else
            {
                lstbxAccounts.ItemsSource = accounts;
            }
        }

        private void lstbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account account = lstbxAccounts.SelectedItem as Account;

            if (account != null)
            {
                tblkFirstName.Text = account.FirstName;
                tblkSurname.Text = account.LastName;
                tblkBalance.Text = account.Balance.ToString();
                tblkAccountType.Text = account.AccountType;
                tblkIntrerestDate.Text = account.InterestDate.ToString("d");
            }
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            if (tbxTransactionAmount.Text != null)
            {

            }
        }
    }
}