using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandsStockManagement
{
    //facade design pattern in the action
    internal class RemovalFacade
    {

        //creates objec of the ticket class and also the remove and updating of the items
        TicketCreation ticket = new TicketCreation();
        InventoryAddRemove inventoryAddRemove = new InventoryAddRemove();

        public void removeItem(string code, Dictionary<string, Product> productsDic)
        {
            ticket.createTicket("remove");
            inventoryAddRemove.process(ticket, productsDic, code, 0);
        }

        public void updateItem(string code, Dictionary<string, Product> productsDic, int quantity)
        {
            ticket.createTicket("update");
            inventoryAddRemove.process(ticket, productsDic, code, quantity);
        }
    }
}
