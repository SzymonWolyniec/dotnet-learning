using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class Doctor : Person
    {
        public static string DoctorInfo => "\n=== DOCTOR INFORMATION ===\n";

        private DoctorSpecialization _specialization = DoctorSpecialization.None;
        public DoctorSpecialization Specialization
        {
            get => _specialization;
            set
            {
                if (Enum.IsDefined(typeof(DoctorSpecialization), value))
                    _specialization = value;
                else
                    throw new ArgumentException("Invalid specialization.", nameof(Specialization));
            }
        }

        private string _licenseNumber = "PWZ-000000";
        public string LicenseNumber
        {
            get => _licenseNumber;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && System.Text.RegularExpressions.Regex.IsMatch(value, @"^PWZ-\d{6}$"))
                    _licenseNumber = value;
                else
                    throw new ArgumentException("Invalid license number format.", nameof(LicenseNumber));
            }

        }


        public Doctor(string name, int age, double height, double weight, DoctorSpecialization specialization, string licenseNumber, Address? address = null)
            : base(name, age, height, weight, address)
        {
            Specialization = specialization;
            LicenseNumber = licenseNumber;
        }

        public override void PresentBMI()
        {
            Console.Write($"My BMI as a Doctor is ");
            base.PresentBMI();
        }

        public override void Introduce()
        {
            Console.WriteLine($"{Consts.IntroductionName} {Name}. My specialization is {Specialization}.");
        }

        public override string ToString()
        {
            return $"Age: {Age} yo\n" +
                   $"Height: {Height} cm\n" +
                   $"Weight: {Weight} kg\n" +
                   $"License Number: {LicenseNumber}";
        }



    }
}
