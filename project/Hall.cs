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
        public string PrintDetails()
        {
            string str = "";
            str += $"\nHall {HallId} Capacity {Capacity}";
            str += "\nSessions:";

            foreach (var session in Sessions)
            {
                str +=  $"\nMovie: {session.SMovie.Title}, Time: {session.MovieDate}";
                str += $"\nAvailable Seats:";
                str += "\n";

                var seats = session.AvailableSeats;
                for (int i = 0; i < seats.Count; i++)
                {
                    str += seats[i] + "\t";

                    if ((i + 1) % 5 == 0)
                    {
                        str += "\n";
                    }
                }

                str += "\n";
            }
            return str;
        }

        public int CompareTo(Hall? obj)
       {
           if (obj == null) return 1;
           return Capacity.CompareTo(obj.Capacity);
       }
    }
}
