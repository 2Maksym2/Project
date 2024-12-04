using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public abstract class Ticket
    {
        public abstract double TicketPrice { get; set; }
        public abstract double CalculateTotalPrice();
        public virtual string SuccessfulPurchase()
        {
            return "Successfully purchased a  ticket";
        }
    }
}
