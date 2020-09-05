using OrderManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Classes
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public void ChargeCreditCard(string cardNumber, DateTime cardExpiryDate)
        {
            if (cardNumber is null)
            {
                throw new ArgumentNullException("Invalid card");
            }
            
            if (cardExpiryDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Card is expired");
            }

            // Crazy business logic would go here to actually make payment.

            Console.WriteLine("Call to credit card payment API...");
        }
    }
}
