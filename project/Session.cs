using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Session
    {
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public DateTime MovieDate { get; set; }
        public double TicketPrice { get; set; }
        public List<int> AvailableSeatNumbers { get; set; }

        public Session(Movie movie, Hall hall, DateTime movieDate, double ticketPrice)
        {
            Movie = movie;
            Hall = hall;
            MovieDate = movieDate;
            TicketPrice = ticketPrice;

            AvailableSeatNumbers = new List<int>();
            for (int i = 1; i <= hall.Capacity; i++)
            {
                AvailableSeatNumbers.Add(i);
            }
        }

        public bool IsSessionFull()
        {
            throw new NotImplementedException();
        }

        public void ReserveSeats(List<int> seatNumbers)
        {
            throw new NotImplementedException();
        }
    }
}
