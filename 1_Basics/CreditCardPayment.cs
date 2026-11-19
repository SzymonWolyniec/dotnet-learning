using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class CreditCardPayment : IPaymentMethod, IRefundable
    {
        void IPaymentMethod.Process(decimal amount)
        {
            ProcessPayment(amount);
        }

        void IRefundable.Process(decimal amount)
        {
            Refund(amount);
        }

        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}.");


            if (amount > 0)
                Console.WriteLine("Payment successful.");
            else
                Console.WriteLine("Invalid payment amount.\n" +
                    "Payment failed.");



        }

        public void Refund(decimal amount)
        {
            Console.WriteLine($"Processing credit card refund of {amount:C}.");
        }
    }


}
