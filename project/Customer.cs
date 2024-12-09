using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Customer
    {
        public delegate void TicketOperation(string message);
        public event TicketOperation TicketPurchased;

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
            TicketPurchased?.Invoke("Thank you for purchasing the ticket.");
            return new TicketSingle(seatNumber, session.TicketPrice);
        }

        public TicketGroup BuyGroupTickets(Session session, List<int> seatNumbers)
        {
            session.ReserveSeats(seatNumbers);
            TicketPurchased?.Invoke("Thank you for purchasing the ticket.");
            return new TicketGroup(seatNumbers, session.TicketPrice);
        }
       
    }
}
