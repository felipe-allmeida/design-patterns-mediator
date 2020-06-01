using DesignPatterns.Mediator.Data;
using DesignPatterns.Mediator.Models;
using DesignPatterns.Mediator.Notifications;
using DesignPatterns.Mediator.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Mediator
{
    class Program
    {
        static NotificationHandler Mediator = new NotificationHandler();
        static void Main(string[] args)
        {
            var repository = InitMockedRepository();

            var registerService = new RegisterService(Mediator, repository);
            var rentService = new RentService(Mediator, repository);

            while(true)
            {                
                Console.WriteLine("1 - Add Product");
                Console.WriteLine("2 - Rent Product");
                Console.WriteLine("3 - List Products");
                Console.WriteLine("4 - Close");
                Console.Write("Enter: ");

                var input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        RegisterProduct(registerService);
                        break;
                    case "2":
                        RentProduct(rentService);
                        break;
                    case "3":
                        repository.GetAll().ForEach(x => Console.WriteLine(x.Name.PadRight(40) + x.Description));
                        break;
                }

                Console.WriteLine("Press anything to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void ShowErrors(NotificationHandler mediator)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A unexpected situation happend:");
            foreach(var error in mediator.GetNotifications())
            {
                Console.WriteLine(error);
            }
            mediator.ClearNotifications();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void RentProduct(RentService rentService)
        {
            Console.Write("Enter the product name to rent: ");
            string name = Console.ReadLine();

            Product product = rentService.RentProduct(name);

            if (product == null)
            {
                ShowErrors(Mediator);
            }
            else
            {
                Console.WriteLine($"Product {product.Name} rented!");
            }
        }

        private static void RegisterProduct(RegisterService registerService)
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            decimal price = 0;
            decimal.TryParse(Console.ReadLine(), out price);

            if (!registerService.RegisterProduct(name, description, price))
            {
                ShowErrors(Mediator);
            }
            else
            {
                Console.WriteLine($"Product {name} registerd!");
            }
        }

        private static MockedProductRepository InitMockedRepository()
        {
            return new MockedProductRepository(new List<Product>
            {
                new Product("Camiseta Branca", "Tamanho G", 49.99M),
                new Product("Camiseta Preta", "Tamanho M", 39.99M),
                new Product("Camiseta Azul", "Tamanho p", 29.99M),
            });
        }
    }
}
