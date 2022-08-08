using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandsStockManagement
{
    internal class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }

        public IApparel ProductType { get; set; }

        public Product(string code, string name, double price, int qty, IApparel productType)
        {
            Code = code;
            Name = name;
            Price = price;
            Qty = qty;
            ProductType = productType;
        }

        //prototype design pattern
        public Product DeepCopy()
        {
            Product product = (Product)this.MemberwiseClone();
            if (this.ProductType.GetType() == typeof(Jeans))
            {
                product.ProductType = new Jeans();
            }
            else
            {
                product.ProductType = new Tshirt();
            }
            return product;
        }
    }
}
