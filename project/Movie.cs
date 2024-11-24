using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Movie
    {
        public List<Movie> Films { get; } = new List<Movie>();
        public FilmType Genre { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int AgeRestriction { get; set; }
        public double TicketPrice { get; set; }

        public Movie(FilmType genre, string title, int duration, int ageRestriction, double ticketPrice)
        {
            Genre = genre;
            Title = title;
            Duration = duration;
            AgeRestriction = ageRestriction;
            TicketPrice = ticketPrice;
        }

        public List<Movie> AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
