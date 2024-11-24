using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Cashier
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Cashier(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
    }
}
