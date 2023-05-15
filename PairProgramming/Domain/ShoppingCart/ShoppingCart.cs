using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShoppingCart
{
    public class ShoppingCart
    {
        private List<Product> products = new List<Product>();
        private ILogger logger = null;
        private readonly int discountSetNo = 2;
        public ShoppingCart(ILogger logger)
        {
            this.logger = logger;
        }

        public void Add(Product item)
        {
            products.Add(item);
            logger.Log("Item added :" + item.ProductName + ", " + item.ProductCode);
        }

        public void Remove(Product item)
        {
            products.Remove(item);
            logger.Log("Item removed :" + item.ProductName + ", " + item.ProductCode);
        }
        public int ProductCount()
        {
            return products.Where(x => x.Availabilty == true).Count();
        }

        public int TotalPrice()
        {
            //return products.Where(x => x.Availabilty == true).Select(x => x.ProductPrice).Sum();
            //return GetDiscountedJeansPrice() + GetUnDiscountedPrice();

            return GetDiscountedPrice("020", 20, 30) + GetDiscountedPrice("010", 10, 15);
        }

        private int GetDiscountedPrice(string productCode, int productPrice, int setPrice)
        {
            var selectedProducts = products.Where(x => x.Availabilty == true && x.ProductCode == productCode);

            int setCount = selectedProducts.Count();
            
            int batchCount = setCount/ discountSetNo;
            int setTotalPrice = batchCount * setPrice;
            int incompleteSetPrice = setCount % discountSetNo * productPrice;
            int totalPrice = setTotalPrice + incompleteSetPrice;
            return totalPrice;
        }

        //private int GetDiscountedJeansPrice()
        //{
        //    var jeans = products.Where(x => x.Availabilty == true && x.ProductCode == "020");

        //    int jeansCount = jeans.Count();
        //    int batchCount = jeansCount / 3;
        //    int batchPrice = batchCount * 2 * 20;   // 3 items for price of 2. Each jeans costs 20
        //    int totalJeansPrice = jeansCount % 3 * 20 + batchPrice;

        //    return totalJeansPrice;
        //}

        //private int GetUnDiscountedPrice()
        //{
        //    return products.Where(x => x.Availabilty == true && x.ProductCode != "020").Select(x => x.ProductPrice).Sum();
        //}
    }
}
