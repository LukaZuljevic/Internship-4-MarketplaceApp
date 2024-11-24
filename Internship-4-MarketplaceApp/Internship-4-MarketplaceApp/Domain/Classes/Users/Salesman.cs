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
            if (ListOfProducts.Contains(product) && product.Status != Data.Enum.Status.Prodano)
                Console.WriteLine("Uspjesno kupljen proizvod!");
            else
            {
                Console.WriteLine("Taj proizvod ne postoji!");
                return;
            }
            product.Status = Data.Enum.Status.Prodano;
            SoldProducts.Add(product);
        }

        public void PrintAllProducts()
        {
            Console.Clear();
            Console.WriteLine($"Proizvodi korisnika {Name}: \n");
            foreach(var product in ListOfProducts)
            {
                Console.WriteLine($"Product:  {product.Name} - {product.Description} - {product.Price}eura - {product.Status}");
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

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Earnings: {Earnings}";
        }
    }
}
