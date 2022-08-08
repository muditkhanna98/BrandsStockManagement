using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandsStockManagement
{
    internal class Inventory
    {
        static Inventory? inventoryInstance = null;
        Dictionary<string, Product> productsDic = new Dictionary<string, Product>();
        public static Stack<string> processInfoStack = new Stack<string>();

        //object of the facade
        RemovalFacade removeFacade = new RemovalFacade();
        private Inventory() { }

        //singleton design pattern in action
        public static Inventory getInventoryObj()
        {
            if (inventoryInstance == null)
            {
                inventoryInstance = new Inventory();
            }
            return inventoryInstance;
        }

        //adds products to the dictionary
        public void AddProductsToInventory(List<Product> productList)
        {
            foreach (Product product in productList)
            {
                productsDic.Add(product.Code, product);
                processInfoStack.Push("Added " + product.Name + " to the inventory");
            }
        }

        //iterates over the dictionary to display the products and their details
        public void DisplayInventory()
        {
            foreach (KeyValuePair<string, Product> entry in productsDic)
            {
                Console.WriteLine("Product Code: " + entry.Key + ", Product Name: " + entry.Value.Name
                    + ", Product type: " + entry.Value.ProductType.DiplayType() + ", Quantity: " + entry.Value.Qty);
            }
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        //displays all the processes in the stack 
        public void DisplayProcesses()
        {
            Console.WriteLine("Last process: " + processInfoStack.Peek());
            Console.WriteLine("History of processes from latest to oldest: ");
            Console.WriteLine("--------------------------------------------");
            int sNo = 1;
            foreach (var item in processInfoStack)
            {
                Console.WriteLine(sNo + ") " + item);
                sNo++;
            }
        }

        //use of facase design pattern using the facade class which creates the ticket and also deletes the item from inventory
        public void RemoveProduct(string code)
        {
            removeFacade.removeItem(code, this.productsDic);
        }

        //use of facase design pattern using the facase class which creates the ticket and also updates the item from inventory
        public void UpdateQuantity(string code, int quantity)
        {
            removeFacade.updateItem(code, this.productsDic, quantity);
        }

        public void AddtoCart(string code)
        {
            Product cloneProduct = this.productsDic[code].DeepCopy();
            Console.WriteLine(cloneProduct.ProductType);
            this.productsDic[code].Qty -= 1;
        }
    }
}
