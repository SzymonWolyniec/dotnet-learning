using System.Globalization;

namespace _1_Basics
{
    internal class Program
    {
        private static bool _isTesting = false;

        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine(Patient.PatientInfo);


            Patient patient1 = new Patient("Michael Johnson", 45, 182.5, true);

            Patient patient2 = patient1.ShallowCopy();
            patient2.Name = "Anna Kowalska";
            patient2.Age = 30;


            Console.WriteLine($"Patient 1 Name: {patient1.Name}");
            Console.WriteLine($"Patient 1 Age: {patient1.Age} yo");
            Console.WriteLine($"Patient 1 Height: {patient1.Height} cm");
            Console.WriteLine($"Patient 1 Is Active: {patient1.IsActive}");

            Console.WriteLine($"Patient 2 Name: {patient2.Name}");
            Console.WriteLine($"Patient 2 Age: {patient2.Age} yo");
            Console.WriteLine($"Patient 2 Is Active: {patient2.IsActive}");

            patient2.ToggleActiveStatus();
            Console.WriteLine($"Patient 2 Is Active: {patient2.IsActive}");

            Console.WriteLine(Patient.IsValidAge(25));
            Console.WriteLine(Patient.IsValidAge(-5));

            Console.WriteLine(Patient.IsValidHeight(182.5));
            Console.WriteLine(Patient.IsValidHeight(-10));


            Console.WriteLine(Doctor.DoctorInfo);

            Doctor doctor1 = new Doctor(
                "Dr. John Smith",
                42,
                180,
                DoctorSpecialization.Neurologist,
                "PWZ-123456");


            Console.WriteLine(doctor1);
            Console.WriteLine("\n");


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
    }
}
