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
            if (offer != null)
            {
                offers.Add(offer);
            }
            else
            {
                throw new ArgumentNullException("Empty special offer");
            }
        }

        public double GetTotalPrice()
        {
            double total = 0;

            var distinctProducts = products.GroupBy(x => x.SKU);

            foreach (var product in distinctProducts)
            {
                var offerPricing = offers.SingleOrDefault(x => x.SKU == product.Key);

                if (offerPricing == null)
                {
                    total += products.Sum(x => x.UnitPrice);
                }
                else
                {
                    var count = product.Count();

                    while (count >= offerPricing.OfferQuantity)
                    {
                        total += offerPricing.SpecialPrice;

                        count = count - offerPricing.OfferQuantity;
                    }

                    var unitPrice = product.ToList().First().UnitPrice;
                    total += unitPrice * count;

                }
            }

            return total;
        }
    }            
    }
}
