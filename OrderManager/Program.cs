using System;

namespace OrderManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = string.Empty;
            var orderManager = new OrderManager();
            var cardNumber = string.Empty;
            var cardExpiryDate = string.Empty;
            int cardNumberParsed = 0;
            DateTime cardExpiryDateParsed = new DateTime();

            while (product != "exit")
            {
                Console.WriteLine(@"Enter a Product:
                Keyboard = 0,
                Computer = 1,
                VRHeadset = 2,
                Mouse = 3");
                Console.Write("Product Number : ");
                product = Console.ReadLine();

                if(Enum.TryParse(product, out Product productEnum))
                {
                    if(Enum.IsDefined(typeof(Product), productEnum))
                    {
                        Console.WriteLine("Selected Product : " + productEnum.ToString());

                        do
                        {
                            Console.Write("Card number : ");
                            cardNumber = Console.ReadLine();
                        } while (!int.TryParse(cardNumber, out cardNumberParsed));

                        do
                        {
                            Console.WriteLine("Card expiry date (MM/YYYY) : ");
                            cardExpiryDate = Console.ReadLine();
                        } while (!DateTime.TryParse(cardExpiryDate, out cardExpiryDateParsed));

                        orderManager.Submit(productEnum, cardNumberParsed, cardExpiryDateParsed);
                        Console.WriteLine("Submitted payment.");
                    }
                    else
                    {
                        Console.WriteLine("Error : Number specified is not a valid product number");
                    }
                }
                else
                {
                    Console.WriteLine("Error : Failed to convert input into an enum.");
                }

                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
