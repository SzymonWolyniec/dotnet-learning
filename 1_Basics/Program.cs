using System.Globalization;

namespace _1_Basics
{
    internal class Program
    {
        private static bool _isTesting = false;

        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            //PersonsTest();
            PaymentsTest();

        }

        private static void PaymentsTest()
        {
            IPaymentMethod paymentMethod1 = new BLIKPayment();

            Console.WriteLine(IPaymentMethod.PaymentInfo);
            paymentMethod1.ProcessPayment(100);

            Console.WriteLine(IPaymentMethod.PaymentInfo);
            paymentMethod1.ProcessPayment(210);

            decimal amount = 10;


            if (amount > Consts.BlikMaxAmount)
            {
                /* // If the amount exceeds the BLIK maximum limit, process the payment using a credit card instead (no info).
                 Console.WriteLine(IPaymentMethod.PaymentInfo);
                 (paymentMethod1 as CreditCardPayment ?? new CreditCardPayment()).ProcessPayment(amount);*/

                if (paymentMethod1 is BLIKPayment)
                {
                    Console.WriteLine($"Processing payment of {amount:C}. " +
                        "Amount exceeds BLIK limit. " +
                        "Do you want to pay by credit card? (Y/N)");

                    string? answer = Console.ReadLine();

                    if (string.Equals(answer, "Y", StringComparison.OrdinalIgnoreCase))
                    {
                        new CreditCardPayment().ProcessPayment(amount);
                    }
                    else if (string.Equals(answer, "N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Payment cancelled.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Payment cancelled.");
                    }
                }
                else
                {
                    paymentMethod1.ProcessPayment(amount);
                }

            }
            else
                paymentMethod1.ProcessPayment(amount);


            CreditCardPayment creditCardPayment = new CreditCardPayment();
            IPaymentMethod creditCardPaymentInterface = creditCardPayment;
            IRefundable creditCardRefunableInterface = creditCardPayment;

            Console.WriteLine(IPaymentMethod.PaymentInfo);
            creditCardPayment.ProcessPayment(50);
            creditCardPaymentInterface.Process(50);

            Console.WriteLine(IRefundable.RefundInfo);
            creditCardPayment.Refund(20);
            creditCardRefunableInterface.Process(20);


        }





        private static void PersonsTest()
        {
            Person patient1 = new Patient("Michael Johnson", 45, 182.5, 85.0, true);

            // For testing purposes; patient1 could be a Doctor, so its type should be checked before calling ShallowCopy().
            Patient patient2 = ((Patient)patient1).ShallowCopy();
            patient2.Name = "Anna Kowalska";
            patient2.Age = 30;
            patient2.Height = 165.0;
            patient2.Weight = 60.0;
            patient2.ToggleActiveStatus();

            DisplayPersonInfo(patient1);
            DisplayPersonInfo(patient2);


            Doctor doctor1 = new Doctor(
                "Dr. John Smith",
                42,
                180,
                95,
                DoctorSpecialization.Neurologist,
                "PWZ-123456");

            DisplayPersonInfo(doctor1);

            // FOR TESTING: Displaying doctor information using reflection
            if (_isTesting)
            {
                foreach (var property in doctor1.GetType().GetProperties())
                {
                    if (property.GetMethod?.IsStatic == true)
                        continue;

                    Console.WriteLine($"{property.Name}: {property.GetValue(doctor1)}");
                }
            }

        }


        private static void DisplayPersonInfo(Person person)
        {
            if (person is Patient)
                Console.WriteLine(Patient.PatientInfo);
            else if (person is Doctor)
                Console.WriteLine(Doctor.DoctorInfo);
            else
            {
                Console.WriteLine("Unknown person type.");
                return;
            }

            person.Introduce();
            Console.WriteLine(person);
            person.PresentBMI();
        }
    }
}
