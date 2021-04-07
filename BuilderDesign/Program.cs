using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.DoWorks(builder);
            var product = builder.GetProduct();

            Console.WriteLine(product.ProductId);
            Console.WriteLine(product.ProductName);
            Console.WriteLine(product.CategoryName);
            Console.WriteLine(product.UnitPrice);
            Console.WriteLine(product.Discount);
            Console.WriteLine(product.AppliedDiscount);

            Console.ReadLine();
        }
    }
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool AppliedDiscount { get; set; }
    }
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract Product GetProduct();
    }
    class NewCustomerProductBuilder : ProductBuilder
    {
        Product product = new Product();
        public override void ApplyDiscount()
        {
            product.Discount = product.UnitPrice * (decimal)0.9;
            product.AppliedDiscount = true;
        }

        public override Product GetProduct()
        {
            return product;
        }

        public override void GetProductData()
        {
            product.ProductId = 1;
            product.ProductName = "Asus";
            product.CategoryName = "Computer";
            product.UnitPrice = 20000;
        }
    }
    class OldCustomerProductBuilder : ProductBuilder
    {
        Product product = new Product();
        public override void ApplyDiscount()
        {
            product.Discount = product.UnitPrice;
            product.AppliedDiscount = false;
        }

        public override Product GetProduct()
        {
            return product;
        }

        public override void GetProductData()
        {
            product.ProductId = 1;
            product.ProductName = "Asus";
            product.CategoryName = "Computer";
            product.UnitPrice = 20000;
        }
    }
    class ProductDirector
    {
        public void DoWorks(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
