using DesignPatterns.Mediator.Data;
using DesignPatterns.Mediator.Models;
using DesignPatterns.Mediator.Services;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = InitMockedRepository();

            var registerService = new RegisterService(repository);
            var rentService = new RentService(repository);
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
