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
        public List<Session> Sessions { get; set; } = new List<Session>();

        public Hall(int hallId, int capacity)
        {
            HallId = hallId;
            Capacity = capacity;
        }
        public void AddSession(Session session)
        {
            throw new NotImplementedException();

        }
        public void PrintDetails()
        {
            throw new NotImplementedException();
        }

    }
}
