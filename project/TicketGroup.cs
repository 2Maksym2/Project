using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class TicketGroup
    {
        public List<int> SeatNumbers { get; set; } 
        public double TicketPrice { get; set; } 

        public TicketGroup(List<int> seatNumbers, double ticketPrice)
        {
            SeatNumbers = seatNumbers;
            TicketPrice = ticketPrice;
        }

        public double CalculateTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
