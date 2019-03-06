using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            VPBankTransaction tvp = new VPBankTransaction("001", "08/10/2012", 78900.00);
            TPBankTransaction ttp = new TPBankTransaction("9/10/2012", 451990.00);

            ArrayList lstBank = new ArrayList();

            lstBank.Add(tvp);
            lstBank.Add(ttp);

            foreach (ITransactions bank in lstBank)
            {
                bank.showTransaction();
            }
            //Console.ReadKey();
        }
    }
}
