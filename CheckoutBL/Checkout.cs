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

            var distinctProducts = products.Distinct();

            foreach (var product in distinctProducts)
            {
                var countOfProducts = products.Where(x => x.SKU == product.SKU).Count();
                var offerRule = offers.SingleOrDefault(x => x.SKU == product.SKU);

                if (offerRule != null)
                {
                    while (countOfProducts >= offerRule.OfferQuantity)
                    {
                        total += offerRule.SpecialPrice;
                        countOfProducts -= offerRule.OfferQuantity;
                    }

                    total += product.UnitPrice * countOfProducts;
                }
                else
                {
                    total += products.Sum(x => x.UnitPrice);
                }                
            }

            return total;
        }            
    }
}
