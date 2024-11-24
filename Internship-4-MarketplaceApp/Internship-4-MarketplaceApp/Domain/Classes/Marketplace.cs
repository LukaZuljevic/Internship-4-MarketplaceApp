using Internship_4_MarketplaceApp.Domain.Classes.Users;

namespace Internship_4_MarketplaceApp.Domain.Classes
{
    public class Marketplace
    {
        public List<User> Users { get; }
        public List<Product> ListOfProducts { get; }
        public List<Transaction> ListOfTransactions { get; }
        public double MarketplaceBalance { get; private set; }

        public Marketplace()
        {
            Users = new List<User>();
            ListOfProducts = new List<Product>();
            ListOfTransactions = new List<Transaction>();
            MarketplaceBalance = 0;
        }

        public bool SellProduct(Product product, Customer customer)
        {
            if (!ListOfProducts.Contains(product) || product.Status == Data.Enum.Status.Prodano)
            {
                Console.WriteLine("Taj proizvod ne postoji ili je vec prodan!\n");
                return false;
            }

            if (customer.Balance < product.Price)
            {
                Console.WriteLine("Kupac nema dovoljno para za ovaj proizvod!\n");
                return false;
            }

            Console.WriteLine("Uspjesno kupljen proizvod!\n");

            Transaction newTransaction = new Transaction(customer, product.Salesman, DateTime.Now, Data.Enum.TransactionType.Kupnja);
            ListOfTransactions.Add(newTransaction);

            product.Salesman.SellProduct(product);
            customer.BuyProduct(product);

            product.Salesman.SetEarnings((product.Price - product.Price*0.05));
            customer.SetBalance(-product.Price);
            SetBalance(product.Price * 0.05);

            return true;
        }

        public void AddNewUser(User newUser)
        {
            Users.Add(newUser);
        }

        public void AddNewProduct(Product newProduct)
        {
            ListOfProducts.Add(newProduct);
        }

        public void AddNewTransaction(Transaction transaction)
        {
            ListOfTransactions.Add(transaction);
        }

        public void PrintUsers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine($"Ime: {user.Name}, Email: {user.Email}");
            }
        }

        public void PrintProducts()
        {
            Console.Clear();
            Console.WriteLine("Svi proizvodi na marketu\n");
            foreach(var product in ListOfProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("\n");
        }

        public void PrintTransactions()
        {
            Console.Clear();
            Console.WriteLine("Sve transakcije\n");
            foreach (var transaction in ListOfTransactions)
            {
                Console.WriteLine(transaction.ToString());
            }
            Console.WriteLine("\n");
        }

        public void SetBalance(double amount)
        {
            MarketplaceBalance += amount;
        }
    }
}
