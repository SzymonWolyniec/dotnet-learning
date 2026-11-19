using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class PersonValidator
    {
        public static bool IsValidName(string name) => !string.IsNullOrWhiteSpace(name);

        public static bool IsValidAge(int age) => age >= 0;

        public static bool IsValidHeight(double height) => height >= 1.0;

        public static bool IsValidWeight(double weight) => weight >= 0.1;

        private static bool IsValidLicense(string licenseNumber) => !string.IsNullOrWhiteSpace(licenseNumber) && System.Text.RegularExpressions.Regex.IsMatch(licenseNumber, @"^PWZ-\d{6}$");

        private static bool IsValidSpecialization(DoctorSpecialization specialization) => Enum.IsDefined(typeof(DoctorSpecialization), specialization);


        public static bool IsPersonValid(string name, int age, double height, double weight)
        {
            return IsValidName(name)
                && IsValidAge(age)
                && IsValidHeight(height)
                && IsValidWeight(weight);
        }

        public static bool IsPatientValid(Patient patient)
        {
            if (patient == null) return false;
            return IsPersonValid(
              patient.Name,
              patient.Age,
              patient.Height,
              patient.Weight);
        }

        public static bool IsDoctorValid(Doctor doctor)
        {
            if (doctor == null) return false;
            if (!IsPersonValid(doctor.Name, doctor.Age, doctor.Height, doctor.Weight)) return false;
            if (!IsValidLicense(doctor.LicenseNumber)) return false;
            if (!IsValidSpecialization(doctor.Specialization)) return false;
            return true;
        }


    }
}
