namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Customer : User
    {
        public double Balance { get; private set; }
        public List<Product> BoughtProducts { get; set; }
        public List<Product> FavoriteProducts { get; set; }

        public Customer(string name, string email, double balance) : base(name, email)
        {
            Balance = balance;
            BoughtProducts = new List<Product>();
            FavoriteProducts = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            BoughtProducts.Add(product);
        }

        public void ReturnProduct(Product product, Marketplace marketplace)
        {
            if(product == null)
                return;

            if (!BoughtProducts.Contains(product))
            {
                Console.WriteLine("Taj proizvod nije tvoj.\n");
                return;
            }

            Transaction newTransaction = new Transaction(this, product.Salesman, DateTime.Now, Data.Enum.TransactionType.Povrat, product);
            marketplace.AddNewTransaction(newTransaction);

            BoughtProducts.Remove(product);
            product.Salesman.SoldProducts.Remove(product);

            product.OnSale();

            product.Salesman.SetEarnings((0.15*product.Price - product.Price));
            SetBalance(product.Price * 0.8);

            Console.WriteLine("Uspjesno ste vratili proizvod!\n");
        }

        public void SetBalance(double amount)
        {
            Balance += amount;
        }

        public void PrintBoughtProducts()
        {
            Console.Clear();
            if(BoughtProducts.Count == 0)
            {
                Console.WriteLine("Nisi jos nista kupio!\n");
                return;
            }

            Console.WriteLine("Kupljeni proizvodi\n");
            foreach(var product in BoughtProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("\n");
        }

        public void AddProductToFavorite(Product product)
        {
            Console.Clear();
            FavoriteProducts.Add(product);
            Console.WriteLine("Uspjesno dodan proizvod u favorite.\n");
        }

        public void PrintFavouriteProducts()
        {
            Console.Clear();
            if (FavoriteProducts.Count == 0) 
            {
                Console.WriteLine("Lista tvojih favorita je prazna.\n");
                return;
            }

            Console.WriteLine("Lista favorita\n");
            foreach(var product in FavoriteProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("\n");
        }

        public double UseCoupon(Product product, Marketplace marketplace)
        {
            Console.Clear();
            marketplace.PrintCoupons();

            while (true)
            {
                Console.Write("Unesi kupon kod: ");
                var couponName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(couponName))
                    return product.Price;

                Coupon coupon = marketplace.ListOfCoupons.FirstOrDefault(c => c.CouponCode == couponName && c.ProductType == product.ProductType && c.ExpirationDate > DateTime.Now);

                if (coupon == null)
                {
                    Console.WriteLine("Kupon ne postoji, ne vrijedi za kategoriju tvog proizvoda ili mu je istekao rok.\n");
                }
                else
                {
                    Console.WriteLine("Kupon uspjesno iskoristen!\n");
                    return (product.Price - product.Price * coupon.PercentageOffPrice);
                }
            }
        }

        public override string ToString()
        {
            return $"Ime: {Name}, Email: {Email}, Stanje racuna: {Balance}";
        }
    }
}
