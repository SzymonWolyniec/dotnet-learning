using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Basics
{
    internal class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public Address(string city, string street, string houseNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(Street)}:{Street}\n{nameof(HouseNumber)}:{HouseNumber}\n{nameof(City)}:{City}";
        }
    }
}
