using Internship_4_MarketplaceApp.Data.Enum;

namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Salesman : User
    {
        public double Earnings { get; private set;}
        public List<Product> ListOfProducts;
        public List<Product> SoldProducts;

        public Salesman(string name, string email) : base(name, email)
        {
            Earnings = 0;
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

            if(ListOfProducts.Count == 0)
            {
                Console.WriteLine("Jos nemas svojih proizvoda na marketu\n");
                return;
            }

            Console.WriteLine($"Proizvodi korisnika {Name}: \n");
            foreach(var product in ListOfProducts)
            {
                Console.WriteLine($"{product.ToString()}");
            }
            Console.WriteLine("\n");
        }

        public void SetEarnings(double amount)
        {
            Earnings += amount;
        }

        public void ProductByCategory(ProductType category)
        {
            Console.Clear();
            bool productFound = false;

            Console.WriteLine($"Prodani prozivodi pod kategorijom '{category}':\n");
            foreach (var product in ListOfProducts)
            {
                if (product.ProductType == category && product.Status == Status.Prodano)
                {
                    Console.WriteLine($"{product.ToString()}");
                    productFound = true;
                }
            }
            Console.WriteLine("\n");

            if (!productFound)
                Console.WriteLine("Nema prodanih proizvoda te kategorije\n");
        }

        public override string ToString()
        {
            return $"Ime: {Name}, Email: {Email}, Zarada: {Earnings}";
        }
    }
}
