using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Interfaces
{
    public interface IOrderManager
    {
        void Submit(Product product, string cardNumber, DateTime cardExpiryDate);
        bool CheckStock(Product product);
    }
}
