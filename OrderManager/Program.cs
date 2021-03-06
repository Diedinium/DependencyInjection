﻿using Microsoft.Extensions.DependencyInjection;
using OrderManager.Dependency;
using OrderManager.Interfaces;
using OrderManager.Repository;
using System;

namespace OrderManager
{
    class Program
    {
        public static readonly IServiceProvider Container = new ContainerBuilder().Build();

        static void Main(string[] args)
        {
            var product = string.Empty;
            var orderManager = Container.GetService<IOrderManager>();
            var cardNumber = string.Empty;
            var cardExpiryDate = string.Empty;
            long cardNumberParsed = 0;
            DateTime cardExpiryDateParsed = new DateTime();

            while (product != "exit")
            {
                Console.WriteLine(
                @"Enter a Product:
    Keyboard = 0
    Computer = 1
    VRHeadset = 2
    Mouse = 3");
                Console.Write("Product Number : ");
                product = Console.ReadLine();

                if (Enum.TryParse(product, out Product productEnum))
                {
                    if (Enum.IsDefined(typeof(Product), productEnum))
                    {
                        Console.WriteLine("Selected Product : " + productEnum.ToString());

                        if (!orderManager.CheckStock(productEnum))
                        {
                            Console.WriteLine($"Sorry, but {productEnum} is not in stock");
                        }
                        else
                        {
                            bool exitCardLoop = false;
                            do
                            {
                                Console.Write("Card number (XXXXXXXXXXXXXXXX) : ");
                                cardNumber = Console.ReadLine();
                                if (!Int64.TryParse(cardNumber, out cardNumberParsed))
                                {
                                    Console.WriteLine("Error: This is not a valid card number.");
                                }
                                else if (cardNumber.Length < 16)
                                {
                                    Console.WriteLine("Error: Card length must be 16 digits long.");
                                }
                                else
                                {
                                    exitCardLoop = true;
                                }
                            } while (!exitCardLoop);

                            bool exitExpiryLoop = false;
                            do
                            {
                                Console.Write("Card expiry date (MM/YYYY) : ");
                                cardExpiryDate = Console.ReadLine();
                                if (!DateTime.TryParse(cardExpiryDate, out cardExpiryDateParsed))
                                {
                                    Console.WriteLine("Error: Date not recongnised as a valid date.");
                                }
                                else
                                {
                                    exitExpiryLoop = true;
                                }
                            } while (!exitExpiryLoop);

                            try
                            {
                                orderManager.Submit(productEnum, cardNumber, cardExpiryDateParsed);
                                Console.WriteLine($"Payment made, {productEnum} being shipped by mail.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
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

                Console.WriteLine("");
            }
        }
    }
}
