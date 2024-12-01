using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Movie
    {
        public FilmType Genre { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public Movie(string title, FilmType genre, int duration)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
        }
    }
}
