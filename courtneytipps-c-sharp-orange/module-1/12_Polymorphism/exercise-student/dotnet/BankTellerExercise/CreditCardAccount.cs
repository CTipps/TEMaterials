using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    class CreditCardAccount : IAccountable
    {
        public string AccountNumber { get; }
        public string AccountHolderName { get; }
        public int AccountChange { get; set; }

        public int Debt
        {
            get
            {
                return AccountChange;
            }
        }

        public int Balance
        {
            get { return AccountChange * -1; }
        }

        public CreditCardAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;

        }

        public int Pay(int amountToPay)
        {
            AccountChange -= amountToPay;
            return AccountChange;
        }
        public int Charge(int amountToCharge)
        {
            AccountChange += amountToCharge;
            return AccountChange;
        }
    }
}
