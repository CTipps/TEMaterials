using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    class BankCustomer
    {
        //variables
        private List<IAccountable> listOfAccounts = new List<IAccountable>();
        private decimal sum = 0;

        //properties
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public double Balance { get; set; }
        public bool IsVip
        {
            get
            {
                foreach (IAccountable accBalance in listOfAccounts)
                {
                    sum += accBalance.Balance;
                }
                if (sum >= 25000)
                {
                    return true;
                }
                else { return false; }
            }
        }

        //constructor(s)

        //methods
        public void AddAccount(IAccountable newAccount) 
        {
            listOfAccounts.Add(newAccount);
        }
        public IAccountable[] GetAccounts() { return listOfAccounts.ToArray(); }

    }
}
