using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class BLIKPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing BLIK payment of {amount:C}.");

            if (amount > 0 && amount <= Consts.BlikMaxAmount)
                Console.WriteLine(
                    "Payment successful.");
            else
                Console.WriteLine("Invalid payment amount.\n" +
                    "Payment failed.");
        }

    }
}
