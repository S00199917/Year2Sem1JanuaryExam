using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override void CalculateInterest()
        {
            
        }
    }
}
