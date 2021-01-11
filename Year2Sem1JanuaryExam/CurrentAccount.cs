using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Year2Sem1JanuaryExam
{
    class CurrentAccount : Account
    {
        private decimal _interestRate = 0.03m;

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

        public CurrentAccount(string firstName, string lastName, decimal balance, int accountNumber) : base(firstName, lastName, balance, accountNumber)
        {
            AccountType = "Current";
        }

        public override decimal CalculateInterest()
        {
            if (InterestDate.ToString("yyyy") != DateTime.Now.ToString("yyyy"))
            {
                InterestDate = DateTime.Now;
                MessageBox.Show("Interest has already been applied this year");
            }

            return Balance * InterestRate;
        }
    }
}
