using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class Person
    {
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
                if (IsValidAge(value)) _age = value;
                else throw new ArgumentOutOfRangeException(nameof(Age), "Age cannot be negative.");
            }
        }
        private double _height = 0.0;
        public double Height
        {
            get => _height;
            set
            {
                if (IsValidHeight(value)) _height = value;
                else throw new ArgumentOutOfRangeException(nameof(Height), "Height cannot be negative.");
            }
        }


        public Person(string name)
        {
            Name = name;
        }

        // Constructor chaining
        public Person(string name, int age, double height)
            : this(name)
        {
            Age = age;
            Height = height;
        }



        public static bool IsValidAge(int age) => age >= 0;

        public static bool IsValidHeight(double height) => height >= 0;

    }
}
