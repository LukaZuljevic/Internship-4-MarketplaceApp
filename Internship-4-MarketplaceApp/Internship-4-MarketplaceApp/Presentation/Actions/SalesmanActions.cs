using Internship_4_MarketplaceApp.Domain.Classes.Users;
using Internship_4_MarketplaceApp.Domain.Classes;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Data.Enum;
using Internship_4_MarketplaceApp.Presentation.Actions;

namespace Internship_4_MarketplaceApp.Presentation.Actions
{
    public class SalesmanActions
    {
        public static void EarningsInTimePeriod(Salesman salesman, Marketplace marketplace)
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

        public static void ChangeProductPrice(Salesman salesman)
        {
            salesman.PrintAllProducts();

            var productId = UserInputHelper.CheckIfValidId(salesman);
            var newPrice = UserInputHelper.CheckIfValidNumber("Unesi novu cijenu proizvoda: ");

            var product = salesman.ListOfProducts.FirstOrDefault(p => p.Id == productId);
            product.ChangePrice(newPrice);

            Console.WriteLine("Cijena uspjesno promijenjena!\n");
        }

        public static void AddProductToSell(Salesman salesman, Marketplace marketplace)
        {
            var productName = UserInputHelper.CheckIfValidString("ime", "proizvoda");
            var productDescription = UserInputHelper.CheckIfValidString("opis", "proizvoda");
            var productPrice = UserInputHelper.CheckIfValidPrice();
            var productType = UserInputHelper.PickProductType();

            Product newProduct = new Product(productName, productDescription, productPrice, Status.Na_prodaju, salesman, ProductType.Odjeca);

            salesman.AddNewProduct(newProduct);
            marketplace.AddNewProduct(newProduct);
        }
    }
}
