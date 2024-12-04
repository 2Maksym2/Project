using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Session
    {
        public Movie SMovie { get; set; }
        public DateTime MovieDate { get; set; }
        public double TicketPrice { get; set; }
        public List<int> AvailableSeats { get; set; }

        public Session(Movie movie,  DateTime movieDate, double ticketPrice, List<int> availableSeats)
        {
            SMovie = movie;
            MovieDate = movieDate;
            TicketPrice = ticketPrice;

            AvailableSeats = availableSeats;
            
        }

        public bool IsSessionFull()
        {
           return AvailableSeats.Count == 0;
        }

        public void ReserveSeats(List<int> seatNumbers)
        {
            foreach (var seat in seatNumbers)
            {
                if (AvailableSeats.Contains(seat))
                {
                    AvailableSeats.Remove(seat);
                }
                else
                {
                    throw new Exception($"Seat {seat} is already reserved or does not exist.");
                }
            }
        }
    }
}
