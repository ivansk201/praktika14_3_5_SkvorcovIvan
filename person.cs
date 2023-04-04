using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prack14zad3_4
{
    public class person
    {
        public string Name { get; set; }
        public string Familiya { get; set; }
        public string Otchestvo { get; set; }
        public int Age { get; set; }
        public double Ves { get; set; }

        public person(string name, string familiya, string otchestvo, int age, double ves)
        {
            Name = name;
            Familiya = familiya;
            Otchestvo = otchestvo;
            Age = age;
            Ves = ves;
        }
    }
}