using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    interface IAccountable
    { 
        string AccountNumber { get; }
        int Balance { get; }
    }
}
