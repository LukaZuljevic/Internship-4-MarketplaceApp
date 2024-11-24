namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Salesman : User
    {
        public double Earnings { get; private set;}
        public List<Product> ListOfProducts;

        public Salesman(string name, string email) : base(name, email)
        {
            ListOfProducts = new List<Product>();
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

        public void RemoveProduct(Product product)
        {
            if (ListOfProducts.Remove(product))
            {
                Console.WriteLine("Uspjesno kupljen proizvod!");
                return;
            }
            else
            {
                Console.WriteLine("Taj proizvod ne postoji!");
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Earnings: {Earnings}";
        }
    }
}
