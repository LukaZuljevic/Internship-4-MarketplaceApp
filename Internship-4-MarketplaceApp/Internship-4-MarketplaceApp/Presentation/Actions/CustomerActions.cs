using Internship_4_MarketplaceApp.Domain.Classes.Users;
using Internship_4_MarketplaceApp.Domain.Classes;

namespace Internship_4_MarketplaceApp.Presentation.Actions
{
    public class CustomerActions
    {
        public static Product PickProductFromMarketplace(Customer customer, Marketplace marketplace)
        {
            Console.Clear();
            marketplace.PrintProducts();
            Console.WriteLine($"Stanje na racunu: {customer.Balance}");

            Product selectedProduct = null;
            while (true)
            {
                Console.Write("\nOdaberi Id jednog od proizvoda na listi: ");
                var pickedProductId = Console.ReadLine();

                if (int.TryParse(pickedProductId, out int productId))
                {
                    selectedProduct = marketplace.ListOfProducts.FirstOrDefault(p => p.Id == productId);

                    if (selectedProduct != null)
                        break;
                    else
                        Console.WriteLine("Proizvod s tim Id-em ne postoji.\n");
                }
                else
                {
                    Console.WriteLine("Krivi unos, Id mora bit broj.\n");
                }
            }

            return selectedProduct;
        }

        public static Product PickProductToReturn(Customer customer)
        {
            Console.Clear();
            customer.PrintBoughtProducts();

            if (customer.BoughtProducts.Count == 0)
                return null;

            Product selectedProduct = null;
            while (true)
            {
                Console.Write("\nOdaberi Id jednog od proizvoda na listi: ");
                var pickedProductId = Console.ReadLine();

                if (int.TryParse(pickedProductId, out int productId))
                {
                    selectedProduct = customer.BoughtProducts.FirstOrDefault(p => p.Id == productId);

                    if (selectedProduct != null)
                        break;
                    else
                        Console.WriteLine("Proizvod s tim Id-em ne postoji!");
                }
                else
                {
                    Console.WriteLine("Krivi unos, Id mora bit broj.");
                }
            }

            return selectedProduct;
        }
    }
}
