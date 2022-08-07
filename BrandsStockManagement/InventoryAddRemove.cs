using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandsStockManagement
{
    internal class InventoryAddRemove
    {
        //Inventory process class to handle delete and update of items inside the inventory
        public void process(TicketCreation ticket, Dictionary<string, Product> productsDic, string code, int quantity)
        {
            if (ticket.type == "remove")
            {
                productsDic.Remove(code);
                Inventory.processInfoStack.Push("Product with code " + code + " removed from inventory");
            }
            else if (ticket.type == "update")
            {
                if (productsDic.ContainsKey(code))
                {
                    productsDic[code].Qty = quantity;
                }

                Inventory.processInfoStack.Push("Product with code " + code + " updated");
            }
        }
    }
}
