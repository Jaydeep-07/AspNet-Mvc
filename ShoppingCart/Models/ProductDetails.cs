using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class ProductDetails
    {

        public int productid { get; set; }
        public string productname { get; set; }
        public Int64 price { get; set; }
        public string productimage { get; set; }

        public List<ProductDetails> productlist { get; set; }
    }
}