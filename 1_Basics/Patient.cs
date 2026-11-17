using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class Patient
    {
        private string _info = "=== PATIENT INFORMATION ===";
        public string Info { get => _info; }


        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or whitespace.", nameof(Name));
                else
                    _name = value;
            }
        }
        private int _age = 0;
        public int Age
        {
            get => _age;
            set
            {
                if (value >= 0) _age = value;
                else throw new ArgumentOutOfRangeException(nameof(Age), "Age cannot be negative.");
            }
        }
        private double _height = 0.0;
        public double Height
        {
            get => _height;
            set
            {
                if (value >= 0) _height = value;
                else throw new ArgumentOutOfRangeException(nameof(Height), "Height cannot be negative.");
            }
        }
        private bool _isActive = false;
        public bool IsActive { get => _isActive; set => _isActive = value; }

        public Patient()
        {
        }

        public Patient(string name)
        {
            Name = name;
        }

        public Patient(string name, int age, double height, bool isActive)
        {
            Name = name;
            Age = age;
            Height = height;
            IsActive = isActive;
        }

        public Patient ShallowCopy()
        {
            return (Patient)MemberwiseClone();
        }

    }
}
