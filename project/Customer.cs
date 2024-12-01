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

        public Customer(string name)
        {
            Name = name;
        }

        public TicketSingle BuySingleTicket(Session session, int seatNumber)
        {
            throw new NotImplementedException();
        }

        public TicketGroup BuyMultipleTickets(Session session, List<int> seatNumbers)
        {
            throw new NotImplementedException();
        }
    }
}
