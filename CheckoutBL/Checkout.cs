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
        public readonly IList<SpecialOffer> offers = new List<SpecialOffer>();

        public void ScanProduct(Product product)
        {
            if (product != null)
            {
                products.Add(product);
            }
            else
            {
                throw new ArgumentNullException("Empty product");
            }
        }

        public void AddSpecialOfferRule(SpecialOffer offer)
        {
            offers.Add(offer);
        }
    }
}
