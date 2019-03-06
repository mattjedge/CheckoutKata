using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL
{
    public class Checkout
    {
        public readonly IList<Product> products = new List<Product>();

        public void ScanProduct(Product product)
        {
            products.Add(product);
        }
    }
}
