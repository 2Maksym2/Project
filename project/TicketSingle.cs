using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class TicketSingle :Ticket
    {
        public  int SeatNumber { get; set; }
        public override double TicketPrice { get; set; } 

        public TicketSingle(int seatNumber, double ticketPrice)
        {
            SeatNumber = seatNumber;
            TicketPrice = ticketPrice;
        }
        public override double CalculateTotalPrice()
        {
           return TicketPrice;
        }
        public override string SuccessfulPurchase()
        {
            return "Successfully purchased a single ticket";
        }
    }
}
