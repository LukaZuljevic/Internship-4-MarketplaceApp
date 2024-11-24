﻿using Internship_4_MarketplaceApp.Data.Enum;
using Internship_4_MarketplaceApp.Domain.Classes.Users;

namespace Internship_4_MarketplaceApp.Domain.Classes
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public double Price { get; private set; }
        public Status Status { get; set; }
        public Salesman Salesman { get; set; }
        public ProductType ProductType { get; set; }

        public Product(string name, string description, double price, Status status, Salesman salesman, ProductType productType)
        {
            Name = name;
            Description = description;
            Price = price;
            Status = status;
            Salesman = salesman;
            ProductType = productType;
        }

        public void OnSale()
        {
            Status = Status.Na_prodaju;
        }

        public void SoldOut()
        {
            Status = Status.Prodano;
        }
    }
}
