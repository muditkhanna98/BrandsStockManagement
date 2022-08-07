using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandsStockManagement
{
    //factory class to get type of apparel object
    internal class ApparelFactory
    {
        public IApparel GetApparel(string type)
        {
            if (type == "Jeans")
            {
                return new Jeans();
            }
            return new Tshirt();
        }
    }
}
