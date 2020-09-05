using OrderManager.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Classes
{
    public class ShippingProcessor
    {
        public void MailProduct(Product product)
        {
            var productStockRepo = new ProductStockRepository();

            productStockRepo.ReduceStock(product);
            
            // Business logic would go here to determine shipping details etc..

            Console.WriteLine("Call to shipping API...");
        }
    }
}
