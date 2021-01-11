using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2Sem1JanuaryExam
{
    abstract class Account
    {
        //Account holders first name
        public string FirstName { get; set; }
        //Account holders surname
        public string LastName { get; set; }
        //Account holders balance
        public decimal Balance { get; set; }
        //Account holders account number
        public int AccountNumber { get; set; }
        //Account holders interest date
        public DateTime InterestDate { get; set; }
        //Account holders account type
        public string AccountType { get; set; }

        //Assings each of the properties their corrosponding input from the main .cs page
        public Account(string firstName, string lastName, decimal balance, int accountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            AccountNumber = accountNumber;
        }

        //creates an abstract method
        public abstract decimal CalculateInterest();

        //overrides the ToString() method, used for the list box
        public override string ToString()
        {
            return string.Format($"{AccountNumber} - {LastName}, {FirstName}");
        }
    }
}
