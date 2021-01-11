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
        //Account holders interest date
        public DateTime InterestDate { get; set; }


        public abstract void CalculateInterest();
    }
}
