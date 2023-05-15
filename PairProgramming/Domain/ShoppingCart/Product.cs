using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShoppingCart
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCode { get; set; }
        public bool Availabilty { get; set; }

        public Product(string name, int price, string desc, string code, bool availability)
        {
            ProductName = name;
            ProductPrice = price < 0 ? 0 : price;
            ProductDescription = desc;
            ProductCode = code;
            Availabilty = availability;
        }
    }
}
