using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Cinema
    {
        public List<Cashier> Cashiers { get; } = new List<Cashier>();
        public List<Hall> Halls { get; } = new List<Hall>();
        public Cinema()
        {
            Halls = new List<Hall>
        {
            new Hall (1,100),
            new Hall (1,120),
        };
        }
    } 
}
