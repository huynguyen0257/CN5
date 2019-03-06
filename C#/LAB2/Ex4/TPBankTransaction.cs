using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    class TPBankTransaction : ITransactions
    {
        private string tCode, date;
        private double amount;
        public TPBankTransaction()
        {
            tCode = " ";
            date = " ";
            amount = 0;
        }
        public TPBankTransaction(string d , double a)
        {
            tCode = Guid.NewGuid().ToString();
            date = d;
            amount = a;
        }

        public double getAmount()
        {
            return amount;
        }

        public void showTransaction()
        {
            Console.WriteLine($"Transaction: { tCode} - Date : {date} - Amount: {getAmount()}");
        }
    }
}
