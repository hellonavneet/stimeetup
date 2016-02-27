using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestPayment
{
    /*
    * Input Loan amount, Interest Rate, Payment term (in months)
    * Output Montly payment (principle + interest) to payoff the loan in payment term
    */
    class Program
    {
        static void Main(string[] args)
        {
            int loanAmount = 200000;
            double rate = 0.035;
            int term = 360;
            double payment = 0;
            //define range
            double minPayment = 0;
            double maxPayment = loanAmount;
            Console.WriteLine("Calculating for Loan Amount {0}, Rate {1} Term {2} ..", loanAmount, rate, term);
            do
            {
                payment = (minPayment + maxPayment) / 2;
                int result = checkPayment(loanAmount, rate, term, payment);

                if(result == 0)
                {
                    break;
                }

                if(result == 1)
                {
                    maxPayment = payment;
                }
                else
                {
                    minPayment = payment;
                }

            } while (true);

            Console.WriteLine("Monthly Payment {0}", payment);
        }

        /// <summary>
        /// Checks if the given payment will payoff the loan in given term
        /// </summary>
        /// <param name="loanAmount">Loan </param>
        /// <param name="rate"></param>
        /// <param name="term"></param>
        /// <param name="amountToCheck"></param>
        /// <returns>0 - if amount is correct, 1 - if amountToCheck is greater than monthly payment, -1 otherwise</returns>
        static int checkPayment(int loanAmount, double rate, int term, double amountToCheck)
        {
            double payment = (rate * loanAmount) / (1 -  Math.Pow( (1.0 + rate), term * -1));
            amountToCheck = Math.Ceiling(amountToCheck);
            payment = Math.Ceiling(payment);
            if (amountToCheck == payment)
                return 0;
            if (amountToCheck < payment)
                return -1;

            return 1;
        }
    }
}
