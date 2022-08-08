namespace BrandsStockManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //use of array to store type of apparels person can choose from
            string[] apparelTypes = { "Tshirt", "Jeans" };
            string choice;
            IApparel? apparel = null;
            List<Product> productsList = new List<Product>();

            //object of the factory class
            ApparelFactory apparelFactory = new ApparelFactory();

            Console.WriteLine("Hello, Welcome to the Inventory Management System!");
            Console.WriteLine("Please choose one of the following: ");

            //iterate over the array
            foreach (string apparelType in apparelTypes)
            {
                Console.WriteLine(apparelType);
            }
            choice = Console.ReadLine();

            //get the object of type of apparel based on the choice using the factory method
            apparel = apparelFactory.GetApparel(choice);

            //Display the type chosen
            apparel.DiplayType();

            Console.WriteLine("How many " + choice + "  you want to add to the inventory");
            int value = Convert.ToInt32(Console.ReadLine());


            //add products to the products list
            for (int i = 0; i < value; i++)
            {
                string productCode;
                string productName;
                double productPrice;
                int qty;
                Console.WriteLine("Enter Product Code (Unique): ");
                productCode = Console.ReadLine();
                Console.WriteLine("Enter Product Name: ");
                productName = Console.ReadLine();
                Console.WriteLine("Enter qty: ");
                qty = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter price: ");
                productPrice = Convert.ToDouble(Console.ReadLine());
                Product product = new Product(productCode, productName, productPrice, qty, apparel);
                productsList.Add(product);
            }

            Inventory inventory = Inventory.getInventoryObj();
            inventory.AddProductsToInventory(productsList);

            Console.WriteLine("Current Inventory:");
            Console.WriteLine("------------------");
            inventory.DisplayInventory();

            //remove products from the inventory
            Console.WriteLine();
            Console.WriteLine("Enter the Product code of product you want to remove from the Inventory");
            string pCode = Console.ReadLine();
            inventory.RemoveProduct(pCode);
            inventory.DisplayInventory();

            Console.WriteLine();

            //update product quantity in the inventory
            Console.WriteLine("Enter the Product code to update product quantity");
            string code = Console.ReadLine();
            Console.WriteLine("Enter new quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            inventory.UpdateQuantity(code, quantity);
            inventory.DisplayInventory();

            Console.WriteLine("Enter the product code of product that you want to add to the cart");
            string prodCode = Console.ReadLine();


            //prototype design pattern
            inventory.AddtoCart(prodCode);

            inventory.DisplayInventory();
            inventory.DisplayProcesses();
        }
    }
}