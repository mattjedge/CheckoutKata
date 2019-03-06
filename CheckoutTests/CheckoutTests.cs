using CheckoutBL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _classUnderTest;
        private readonly Product productA = new Product { SKU = 'A', UnitPrice = 50 };
        private readonly Product emptyProduct = null;

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new Checkout();
        }

        [Test]
        public void Checkout_ScanProduct_Should_AddProductToList()
        {
            _classUnderTest.ScanProduct(productA);

            Assert.AreEqual(1, _classUnderTest.products.Count());
            Assert.AreEqual('A', _classUnderTest.products[0].SKU);
        }

        [Test]
        public void Checkout_ScanProduct_Should_ThrowExceptionIfProductNull()
        {
           Assert.Throws<ArgumentNullException>(() => _classUnderTest.ScanProduct(emptyProduct));            
        }
    }
}
