using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Customer(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string BuyTicket(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool CanWatchMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
