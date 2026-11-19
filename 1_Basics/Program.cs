using System.Globalization;

namespace _1_Basics
{
    internal class Program
    {
        private static bool _isTesting = false;

        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;



            Patient patient1 = new Patient("Michael Johnson", 45, 182.5, true);

            Patient patient2 = patient1.ShallowCopy();
            patient2.Name = "Anna Kowalska";
            patient2.Age = 30;
            patient2.Height = 165.0;


            Console.WriteLine(Patient.PatientInfo);

            Console.WriteLine(patient1);
            Console.WriteLine($"\n{patient2}");


            patient2.ToggleActiveStatus();
            Console.WriteLine($"\n{patient2.Name} Is Active: {patient2.IsActive}");



            Doctor doctor1 = new Doctor(
                "Dr. John Smith",
                42,
                180,
                DoctorSpecialization.Neurologist,
                "PWZ-123456");

            Console.WriteLine(Doctor.DoctorInfo);
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


            patient1.Introduce();
            Person person2 = new Patient("Jerry Brown", 27, 185.0, false);
            person2.Introduce();

            doctor1.Introduce();
            Person person1 = new Doctor("Dr. Jane Doe", 35, 170, DoctorSpecialization.Cardiologist, "PWZ-654321");
            person1.Introduce();

            // Doesnt work because Person is now abstract
           /* Person personPerson = new Person("Alice Smith", 30, 165.0);
            personPerson.Introduce();*/


        }
    }
}
