using System.Globalization;

namespace _1_Basics
{
    internal class Program
    {


        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Patient patient1 = new Patient("Michael Johnson", 45, 182.5, true);

            Patient patient2 = patient1.ShallowCopy();
            patient2.Name = "Anna Kowalska";
            patient2.Age = -15;

            Patient patient3 = new Patient();

            Patient patient4 = new Patient("Jan Kowalski");

            Console.WriteLine(patient1.Info + "\n");
            Console.WriteLine($"Patient 1 Name: {patient1.Name}");
            Console.WriteLine($"Age: {patient1.Age} yo");
            Console.WriteLine($"Height: {patient1.Height} cm");
            Console.WriteLine($"Is Active: {patient1.IsActive}");

            Console.WriteLine($"Patient2 Name: {patient2.Name}");
            Console.WriteLine($"Patient3 Name: {patient3.Name}");
            Console.WriteLine($"Patient4 Name: {patient4.Name}");



        }


    }
}
