using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    class VPBankTransaction:ITransactions
    {
        private string tCode, date;
        private double amount;
        public VPBankTransaction()
        {
            tCode = " ";
            date = " ";
            amount = 0;
        }
        public VPBankTransaction(string c , string d, double a)
        {
            tCode = c;
            date = d;
            amount = a;
        }
        
        public double getAmount()
        {
            return amount;
        }
  
        public void showTransaction()
        {
            Console.WriteLine("Transaction: {0}", tCode);
            Console.WriteLine("Date: {0}", date);
            Console.WriteLine("Amount: {0}", getAmount());
        }
    }
}
