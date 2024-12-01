using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class TicketSingle
    {
        public int SeatNumber { get; set; }
        public double TicketPrice { get; set; } 

        public TicketSingle(int seatNumber, double ticketPrice)
        {
            SeatNumber = seatNumber;
            TicketPrice = ticketPrice;
        }
    }
}
