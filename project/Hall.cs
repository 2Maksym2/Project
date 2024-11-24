using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Hall : IPrintable
    {
        public int HallId { get; set; }
        public int Capacity { get; set; }
        public DateTime MovieDate { get; set; }

        public Hall(int hallId, int capacity)
        {
            HallId = hallId;
            Capacity = capacity;
        }

        public void PrintDetails()
        {
            throw new NotImplementedException();
        }

        public List<int> AvailableSeats(int HallId, DateTime movieDate, int capacity)
        {
            throw new NotImplementedException();
        }
    }
}
