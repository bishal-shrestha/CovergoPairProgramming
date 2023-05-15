using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.ShoppingCart;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace TestsMSTest
{
    public class TestLogger : ILogger
    {
        public void Log(string message)
        {

        }
    }

    [TestClass]
    public class ShoppingCartTest
    {


        [TestMethod]
        public void WhenProductAddedToCart_ShouldBeAvailable()
        {
            Product productA = new Product("A", 1, "a", "001", true);
            Product productB = new Product("B", 2, "b", "002", true);
            Product productC = new Product("C", 3, "c", "003", false);

            TestLogger logger = new TestLogger();

            ShoppingCart cart = new ShoppingCart(logger);
            cart.Add(productA);
            cart.Add(productB);
            cart.Add(productC);

            int expectedCount = 2;
            int acutalCount = cart.ProductCount();

            Assert.AreEqual(expectedCount, acutalCount);

        }

        [TestMethod]
        public void WhenProductAddedToCart_ShouldMatchPrice()
        {
            Product tshirt = new Product("Tshirt", 10, "Tshirt small size", "010", true);
            Product jeans = new Product("Jeans", 20, "Jeans medium", "020", true);

            TestLogger logger = new TestLogger();

            ShoppingCart cart = new ShoppingCart(logger);
            cart.Add(tshirt);
            cart.Add(jeans);

            int expectedPrice = 30;
            int acutalPrice = cart.TotalPrice();

            Assert.AreEqual(expectedPrice, acutalPrice);

        }

        //[TestMethod]
        //public void WhenBatchJeansAdded_ShouldApplyDiscount()
        //{
        //    Product jeans1 = new Product("Jeans", 20, "Jeans small", "020", true);
        //    Product jeans2 = new Product("Jeans", 20, "Jeans medium", "020", true);
        //    Product jeans3 = new Product("Jeans", 20, "Jeans large", "020", true);

        //    TestLogger logger = new TestLogger();

        //    ShoppingCart cart = new ShoppingCart(logger);
        //    cart.Add(jeans1);
        //    cart.Add(jeans2);
        //    cart.Add(jeans3);

        //    int expectedPrice = 40;
        //    int acutalPrice = cart.TotalPrice();

        //    Assert.AreEqual(expectedPrice,acutalPrice);
        //}

        //[TestMethod]
        //public void WhenMultipleBatchJeansAndTshirtAdded_ShouldApplyDiscount()
        //{
        //    Product jeans1 = new Product("Jeans", 20, "Jeans small", "020", true);
        //    Product jeans2 = new Product("Jeans", 20, "Jeans medium", "020", true);
        //    Product jeans3 = new Product("Jeans", 20, "Jeans large", "020", true);
        //    Product jeans4 = new Product("Jeans", 20, "Jeans large", "020", true);
        //    Product jeans5 = new Product("Jeans", 20, "Jeans large", "020", true);
        //    Product jeans6 = new Product("Jeans", 20, "Jeans large", "020", true);
        //    Product tshirt = new Product("Tshirt", 10, "Tshirt large", "010", true);

        //    TestLogger logger = new TestLogger();

        //    ShoppingCart cart = new ShoppingCart(logger);
        //    cart.Add(jeans1);
        //    cart.Add(jeans2);
        //    cart.Add(jeans3);
        //    cart.Add(jeans4);
        //    cart.Add(jeans5);
        //    cart.Add(jeans6);
        //    cart.Add(tshirt);

        //    int expectedPrice = 90;
        //    int acutalPrice = cart.TotalPrice();

        //    Assert.AreEqual(expectedPrice, acutalPrice);
        //}

        //[TestMethod]
        //public void WhenMultipleIncompleteBatchJeansAdded_SholdApplyProperDiscount()
        //{
        //    Product jeans1 = new Product("Jeans", 20, "Jeans small", "020", true);
        //    Product jeans2 = new Product("Jeans", 20, "Jeans medium", "020", true);
        //    Product jeans3 = new Product("Jeans", 20, "Jeans large", "020", true);
        //    Product jeans4 = new Product("Jeans", 20, "Jeans large", "020", true);

        //    TestLogger logger = new TestLogger();

        //    ShoppingCart cart = new ShoppingCart(logger);
        //    cart.Add(jeans1);
        //    cart.Add(jeans2);
        //    cart.Add(jeans3);
        //    cart.Add(jeans4);

        //    int expectedPrice = 60;
        //    int acutalPrice = cart.TotalPrice();

        //    Assert.AreEqual(expectedPrice, acutalPrice);
        //}

        [TestMethod]
        public void WhenOneSetProductAdded_ShouldApplyDiscount()
        {
            Product jeans1 = new Product("Jeans", 20, "Jeans small", "020", true);
            Product jeans2 = new Product("Jeans", 20, "Jeans medium", "020", true);
            Product tshirt1 = new Product("Tshirt", 10, "Tshirt large", "010", true);
            Product tshirt2 = new Product("Tshirt", 10, "Tshirt large", "010", true);

            TestLogger logger = new TestLogger();

            ShoppingCart cart = new ShoppingCart(logger);
            cart.Add(jeans1);
            cart.Add(jeans2);
            cart.Add(tshirt1);
            cart.Add(tshirt2);

            int expectedPrice = 45;
            int acutalPrice = cart.TotalPrice();

            Assert.AreEqual(expectedPrice, acutalPrice);
        }

        [TestMethod]
        public void WhenMultipleSetProductAdded_ShouldApplyDiscount()
        {
            Product jeans1 = new Product("Jeans", 20, "Jeans small", "020", true);
            Product jeans2 = new Product("Jeans", 20, "Jeans medium", "020", true);
            Product jeans3 = new Product("Jeans", 20, "Jeans small", "020", true);
            Product jeans4 = new Product("Jeans", 20, "Jeans medium", "020", true);
            Product tshirt1 = new Product("Tshirt", 10, "Tshirt large", "010", true);
            Product tshirt2 = new Product("Tshirt", 10, "Tshirt large", "010", true);
            Product tshirt3 = new Product("Tshirt", 10, "Tshirt large", "010", true);
            Product tshirt4 = new Product("Tshirt", 10, "Tshirt large", "010", true);

            TestLogger logger = new TestLogger();

            ShoppingCart cart = new ShoppingCart(logger);
            cart.Add(jeans1);
            cart.Add(jeans2);
            cart.Add(jeans3);
            cart.Add(jeans4);
            cart.Add(tshirt1);
            cart.Add(tshirt2);
            cart.Add(tshirt3);
            cart.Add(tshirt4);

            int expectedPrice = 90;
            int acutalPrice = cart.TotalPrice();

            Assert.AreEqual(expectedPrice, acutalPrice);
        }

        [TestMethod]
        public void WhenIncompleteMultipleSetProductAdded_ShouldAppyDiscount()
        {
            Product jeans1 = new Product("Jeans", 20, "Jeans small", "020", true);
            Product jeans2 = new Product("Jeans", 20, "Jeans medium", "020", true);
            Product jeans3 = new Product("Jeans", 20, "Jeans medium", "020", true);
            Product tshirt1 = new Product("Tshirt", 10, "Tshirt large", "010", true);
            Product tshirt2 = new Product("Tshirt", 10, "Tshirt large", "010", true);
            Product tshirt3 = new Product("Tshirt", 10, "Tshirt large", "010", true);

            TestLogger logger = new TestLogger();

            ShoppingCart cart = new ShoppingCart(logger);
            cart.Add(jeans1);
            cart.Add(jeans2);
            cart.Add(jeans3);
            cart.Add(tshirt1);
            cart.Add(tshirt2);
            cart.Add(tshirt3);

            int expectedPrice = 75;
            int acutalPrice = cart.TotalPrice();

            Assert.AreEqual(expectedPrice, acutalPrice);
        }
    }
}