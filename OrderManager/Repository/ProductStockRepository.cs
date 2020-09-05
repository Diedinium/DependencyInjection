using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Repository
{
    public class ProductStockRepository
    {
        private static Dictionary<Product, int> _productStockDatabase = Setup();

        private static Dictionary<Product, int> Setup()
        {
            var productStockDatabase = new Dictionary<Product, int>();
            productStockDatabase.Add(Product.Computer, 1);
            productStockDatabase.Add(Product.Keyboard, 3);
            productStockDatabase.Add(Product.Mouse, 2);
            productStockDatabase.Add(Product.VRHeadset, 5);
            return productStockDatabase;
        }

        public bool IsInStock(Product product)
        {
            Console.WriteLine("Call get on Database...");
            return _productStockDatabase[product] > 0;
        }

        public void ReduceStock(Product product)
        {
            Console.WriteLine("Call update on Database...");
            _productStockDatabase[product]--;
        }

        public void AddStock(Product product)
        {
            Console.WriteLine("Call update on Database...");
            _productStockDatabase[product]++;
        }
    }
}
