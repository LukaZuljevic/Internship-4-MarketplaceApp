using Internship_4_MarketplaceApp.Domain.Classes.Users;
using Internship_4_MarketplaceApp.Data.Enum;

namespace Internship_4_MarketplaceApp.Domain.Classes
{
    public class Marketplace
    {
        public List<User> Users { get; }
        public List<Product> ListOfProducts { get; }
        public List<Transaction> ListOfTransactions { get; }
        public List<Coupon> ListOfCoupons { get; }
        public double MarketplaceBalance { get; private set; }

        public Marketplace()
        {
            Users = new List<User>();
            ListOfProducts = new List<Product>();
            ListOfTransactions = new List<Transaction>();
            ListOfCoupons = new List<Coupon>();
            MarketplaceBalance = 0;
        }

        public bool SellProduct(Product product, Customer customer, double discountPrice)
        {
            if (!ListOfProducts.Contains(product) || product.Status == Status.Prodano)
            {
                Console.WriteLine("Taj proizvod ne postoji ili je vec prodan!\n");
                return false;
            }

            if (customer.Balance < discountPrice)
            {
                Console.WriteLine("Kupac nema dovoljno para za ovaj proizvod!\n");
                return false;
            }

            Console.WriteLine("Uspjesno kupljen proizvod!\n");

            Product discountedProduct = product;
            discountedProduct.ChangePrice(discountPrice);

            Transaction newTransaction = new Transaction(customer, product.Salesman, DateTime.Now, TransactionType.Kupnja, discountedProduct);
            ListOfTransactions.Add(newTransaction);

            product.Salesman.SellProduct(product);
            customer.BuyProduct(product);

            product.Salesman.SetEarnings((discountPrice - discountPrice * 0.05));
            customer.SetBalance(-discountPrice);
            SetBalance(discountPrice * 0.05);

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

        public void AddNewCoupon(Coupon coupon)
        {
            ListOfCoupons.Add(coupon);
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

            if(ListOfTransactions.Count == 0)
            {
                Console.WriteLine("Ni jedna transakcija jos nije izvrsena!\n");
                return;
            }

            Console.WriteLine("Sve transakcije\n");
            foreach (var transaction in ListOfTransactions)
            {
                Console.WriteLine(transaction.ToString());
            }
            Console.WriteLine("\n");
        }

        public void PrintCoupons()
        {
            Console.Clear();
            Console.WriteLine("Dostupni kuponi: \n");
            foreach (var coupon in ListOfCoupons)
            {
                Console.WriteLine(coupon.ToString());
            }
            Console.WriteLine("\n");
        }

        public void SetBalance(double amount)
        {
            MarketplaceBalance += amount;
        }
    }
}
