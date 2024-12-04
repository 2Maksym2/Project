using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class TicketGroup:Ticket
    {
        public List<int> SeatNumbers { get; set; }
        public override double TicketPrice { get; set; } 

        public TicketGroup(List<int> seatNumbers, double ticketPrice)
        {
            SeatNumbers = seatNumbers;
            TicketPrice = ticketPrice;
        }

        public override double CalculateTotalPrice()
        {
           return SeatNumbers.Count * TicketPrice;
        }
        public override string SuccessfulPurchase()
        {
            return "Successfully purchased a group ticket";
        }
    }
}
