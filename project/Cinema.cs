using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Cinema
    {
        public List<Hall> Halls { get; set; } = new List<Hall>(); 
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public Cinema()
        {
            Hall hall1 = new Hall(1, 60); 
            Hall hall2 = new Hall(2, 80); 
            Halls.Add(hall1);
            Halls.Add(hall2);
            Halls.Sort();
        }
        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

    } 
}
