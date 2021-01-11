using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Year2Sem1JanuaryExam
{
    class SavingsAccount : Account
    {
        //creates a private variable with a value of 0.06
        private decimal _interestRate = 0.06m;

        //Creates a property with the value of _interestRate
        public decimal InterestRate
        {
            get
            {
                return this._interestRate;
            }
            set
            {
                this._interestRate = value;
            }
        }

        //Assings the account type as well as the other properties
        public SavingsAccount(string firstName, string lastName, decimal balance, int accountNumber) : base(firstName, lastName, balance, accountNumber)
        {
            AccountType = "Savings";
        }

        //Calculates the itnerest
        public override decimal CalculateInterest()
        {
            return Balance * InterestRate;
        }
    }
}
