using Internship_4_MarketplaceApp.Data.Enum;
using Internship_4_MarketplaceApp.Presentation.Helpers;

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
                Console.WriteLine($"{product.ToString()}");

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

            Console.WriteLine($"Prodani prozivodi pod kategorijom '{category}':");
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

        public void ChangeProductPrice()
        {
            PrintAllProducts();

            var productId = UserInputHelper.CheckIfValidId(this);
            var newPrice = UserInputHelper.CheckIfValidNumber("Unesi novu cijenu proizvoda: ");

            var product = ListOfProducts.FirstOrDefault(p => p.Id == productId);
            product.ChangePrice(newPrice);

            Console.WriteLine("Cijena uspjesno promijenjena!\n");
        }

        public void EarningsInTimePeriod(Salesman salesman, Marketplace marketplace)
        {
            Console.Clear();

            var startDate = UserInputHelper.CheckDate("pocetka");
            var endDate = UserInputHelper.CheckDate("kraja");

            while (endDate < startDate)
            {
                Console.WriteLine("Datum kraja ne moze bit prije pocetka!");
                endDate = UserInputHelper.CheckDate("kraja");
            }

            double earnings = 0;

            var filteredTransactions = marketplace.ListOfTransactions
                .Where(transaction => transaction.Salesman == salesman
                    && transaction.DateOfTransaction > startDate
                    && transaction.DateOfTransaction < endDate);

            foreach (var transaction in filteredTransactions)
            {
                switch (transaction.TransactionType)
                {
                    case TransactionType.Kupnja:
                        earnings += transaction.Product.Price * 0.95;
                        break;

                    case TransactionType.Povrat:
                        earnings -= transaction.Product.Price * 0.85;
                        break;
                }
            }

            if (earnings == 0)
                Console.WriteLine($"{salesman.Name} u tom periodu nije zaradio nista.\n ");
            else
                Console.WriteLine($"{salesman.Name} je zaradio {earnings} eura u tom razdoblju\n");
        }

        public void AddProductToSell(Salesman salesman, Marketplace marketplace)
        {
            Console.Clear();

            var productName = UserInputHelper.CheckIfValidString("ime", "proizvoda");
            var productDescription = UserInputHelper.CheckIfValidString("opis", "proizvoda");
            var productPrice = UserInputHelper.CheckIfValidPrice();
            var productType = UserInputHelper.PickProductType();

            Product newProduct = new Product(productName, productDescription, productPrice, Status.Na_prodaju, salesman, ProductType.Odjeca);

            salesman.AddNewProduct(newProduct);
            marketplace.AddNewProduct(newProduct);
        }

        public override string ToString()
        {
            return $"Ime: {Name}, Email: {Email}, Zarada: {Earnings}";
        }
    }
}
