using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Interfaces
{
    public interface IShippingProcessor
    {
        void MailProduct(Product product);
    }
}
