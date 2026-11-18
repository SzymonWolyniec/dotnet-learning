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

        public Doctor(string name)
         : base(name)
        { }

        public Doctor(string name, int age, double height, DoctorSpecialization specialization, string licenseNumber)
            : base(name, age, height)
        {
            Specialization = specialization;
            LicenseNumber = licenseNumber;
        }


        public override string ToString()
        {
            return $"Doctor Name: {Name}\n" +
                   $"Age: {Age} yo\n" +
                   $"Height: {Height} cm\n" +
                   $"Specialization: {Specialization}\n" +
                   $"License Number: {LicenseNumber}";
        }



    }
}
