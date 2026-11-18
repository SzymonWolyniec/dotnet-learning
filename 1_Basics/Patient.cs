using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class Patient : Person
    {
        public static string PatientInfo => "\n=== PATIENT INFORMATION ===\n";

        private bool _isActive = false;
        public bool IsActive { get => _isActive; private set => _isActive = value; }


        public Patient(string name)
            : base(name)
        { }

        public Patient(string name, int age, double height, bool isActive)
            : base(name, age, height)
        {
            IsActive = isActive;
        }


        public override string ToString()
        {
            return $"Patient Name: {Name}\n" +
                   $"Age: {Age} yo\n" +
                   $"Height: {Height} cm\n" +
                   $"Is Active: {IsActive}";
        }


        public Patient ShallowCopy()
        {
            return (Patient)MemberwiseClone();
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void ToggleActiveStatus()
        {
            IsActive = !IsActive;
        }

        public static bool IsPatientValid(Patient patient)
        {
            if (patient == null) return false;
            if (!IsValidAge(patient.Age)) return false;
            if (!IsValidHeight(patient.Height)) return false;
            return true;
        }

        public static bool IsPatientValid(string name, int age, double height)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (!IsValidAge(age)) return false;
            if (!IsValidHeight(height)) return false;
            return true;
        }



    }
}
