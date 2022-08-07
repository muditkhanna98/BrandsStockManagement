using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandsStockManagement
{
    internal class TicketCreation
    {
        static int ticketId = 1;
        //queue to store the tickets in the order of first in first out
        Queue<int> ticketQueue = new Queue<int>();

        public string type;
        public void createTicket(String type)
        {
            this.type = type;
            ticketQueue.Enqueue(ticketId++);
        }
    }


}
