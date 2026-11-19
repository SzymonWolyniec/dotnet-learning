

namespace _1_Basics
{
    internal abstract class Person
    {
        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                if (PersonValidator.IsValidName(value))
                    _name = value;
                else
                    throw new ArgumentException("Name cannot be null or whitespace.", nameof(Name));
            }
        }
        private int _age = 0;
        public int Age
        {
            get => _age;
            set
            {
                if (PersonValidator.IsValidAge(value)) _age = value;
                else throw new ArgumentOutOfRangeException(nameof(Age), "Age cannot be negative.");
            }
        }
        private double _height = 1.0;
        public double Height
        {
            get => _height;
            set
            {
                if (PersonValidator.IsValidHeight(value)) _height = value;
                else throw new ArgumentOutOfRangeException(nameof(Height), "Height cannot be less than 1.0.");
            }
        }

        public Address? Address { get; set; }

        private double _weight = 0.0;
        public double Weight
        {
            get => _weight;
            set
            {
                if (PersonValidator.IsValidWeight(value)) _weight = value;
                else throw new ArgumentOutOfRangeException(nameof(Weight), "Weight cannot be less than 0.1.");
            }
        }


        public Person(string name, int age, double height, double weight, Address? address = null)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            Address = address;
        }

        public abstract void Introduce();

        public virtual void PresentBMI()
        {
            Console.WriteLine($"{Weight / Math.Pow(Height/100.0, 2):F2}");
        }

    }
}
