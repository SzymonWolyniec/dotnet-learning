using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal interface IPaymentMethod
    {
        const string PaymentInfo = "\n=== PAYMENT INFORMATION ===\n";

        void ProcessPayment(decimal amount);

        void Process(decimal amount);

    }
}
