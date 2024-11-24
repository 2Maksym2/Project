using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Ticket
    {
        public int SeatNumber { get; set; }
        public int HallId { get; set; }
        public DateTime MovieDate { get; set; }
        public double TicketPrice { get; set; }
        public Cashier Cashier { get; set; }

        public Ticket(int hallId, DateTime movieDate, double ticketPrice, int seatNumber, Cashier cashier)
        {
            HallId = hallId;
            MovieDate = movieDate;
            TicketPrice = ticketPrice;
            SeatNumber = seatNumber;
            Cashier = cashier;
        }
    }
}
