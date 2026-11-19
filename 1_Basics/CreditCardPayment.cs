using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class CreditCardPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}.");


            if (amount > 0)
                Console.WriteLine("Payment successful.");
            else
                Console.WriteLine("Invalid payment amount.\n" +
                    "Payment failed.");



        }
    }


}
