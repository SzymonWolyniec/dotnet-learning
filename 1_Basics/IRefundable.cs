using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal interface IRefundable
    {
        const string RefundInfo = "\n=== REFUND INFORMATION ===\n";

        void Refund(decimal amount);

        void Process(decimal amount);
    }
}
