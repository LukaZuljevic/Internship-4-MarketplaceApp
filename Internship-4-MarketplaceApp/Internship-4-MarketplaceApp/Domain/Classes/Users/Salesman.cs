using System.Security.Cryptography;

namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Salesman : User
    {
        public double Earnings { get; private set;}
        public List<Product> ListOfProducts;
        public List<Product> SoldProducts;

        public Salesman(string name, string email) : base(name, email)
        {
            ListOfProducts = new List<Product>();
            SoldProducts = new List<Product>();
        }

        public void AddNewProduct(Product newProduct)
        {

            if (ListOfProducts.Contains(newProduct))
            {
                Console.WriteLine("Proizvod vec postoji!");
                return;
            }

            ListOfProducts.Add(newProduct);
        }

        public void SellProduct(Product product)
        {
            product.SoldOut();
            SoldProducts.Add(product);
        }

        public void PrintAllProducts()
        {
            Console.Clear();
            Console.WriteLine($"Proizvodi korisnika {Name}: \n");
            foreach(var product in ListOfProducts)
            {
                Console.WriteLine($"{product.ToString()}");
            }
            Console.WriteLine("\n");
        }

        public double CalculateEarnings()
        {
            Console.Clear();
            Earnings = 0;

            foreach(var product in SoldProducts)
                Earnings += product.Price;


            return Earnings;
        }

        public void ProductByCategory(Data.Enum.ProductType category)
        {
            foreach(var product in ListOfProducts)
            {
                if(product.ProductType == category)
                    Console.WriteLine($"{product.ToString()}");
            }
        }

        public override string ToString()
        {
            return $"Ime: {Name}, Email: {Email}, Zarada: {Earnings}";
        }
    }
}
