using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Hall : IPrintable, IComparable<Hall>
    {
        public int HallId { get; set; } 
        public int Capacity { get; set; } 
        public List<Session> Sessions { get; set; } = new List<Session>();

        public Hall(int hallId, int capacity)
        {
            HallId = hallId;
            Capacity = capacity;
        }
        public void AddSession(Session session)
        {
            Sessions.Add(session);
        }
        public void PrintDetails()
        {
            Console.WriteLine($"Hall {HallId} Capacity {Capacity}");
        Console.WriteLine("Sessions:");

        foreach (var session in Sessions)
        {
            Console.WriteLine($"Movie: {session.SMovie.Title}, Time: {session.MovieDate}");
            Console.WriteLine($"Available Seats:");

            var seats = session.AvailableSeats;
            for (int i = 0; i < seats.Count; i++)
            {
                Console.Write(seats[i] + "\t");

                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine(); 
        }
        }

        public int CompareTo(Hall? obj)
       {
           if (obj == null) return 1;
           return Capacity.CompareTo(obj.Capacity);
       }
    }
}
