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
           if (!session.AvailableSeats.Contains(seatNumber))
                throw new Exception($"Seat {seatNumber} is not available.");

            session.AvailableSeats.Remove(seatNumber);
            return new TicketSingle(seatNumber, session.TicketPrice);
        }

        public TicketGroup BuyGroupTickets(Session session, List<int> seatNumbers)
        {
            session.ReserveSeats(seatNumbers);
            return new TicketGroup(seatNumbers, session.TicketPrice);
        }
    }
}
