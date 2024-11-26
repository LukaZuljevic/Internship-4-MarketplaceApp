using Internship_4_MarketplaceApp.Domain.Classes.Users;
using Internship_4_MarketplaceApp.Domain.Classes;

namespace Internship_4_MarketplaceApp.Presentation.Actions.Menus
{
    public class CustomerMenu
    {
        public static void DisplayCustomerMenu(Customer customer, Marketplace marketplace)
        {
            Console.Clear();
            Console.WriteLine("Dobrodosli u prostor za kupca\n");

            while (true)
            {
                Console.WriteLine("1 - Pegledaj sve dostupne proizvode\n2 - Kupi proizvod\n3 - Vrati kupljeni proizvod\n4 - Dodaj proizvod na omiljenu listu\n5 - Pregledaj povijest kupljenih proizvoda\n6 - Pregledaj listu omiljenih prozivoda\n7 - Vrati se nazad na pocetni menu");
                var userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        marketplace.PrintProducts();
                        Console.WriteLine($"Stanje na racunu: {customer.Balance}\n");
                        break;
                    case "2":
                        var productToBuy = CustomerActions.PickProductFromMarketplace(customer, marketplace);
                        var discountPrice = CustomerActions.UseCoupon(productToBuy, marketplace);
                        marketplace.SellProduct(productToBuy, customer, discountPrice);
                        break;
                    case "3":
                        var productToReturn = CustomerActions.PickProductToReturn(customer);
                        customer.ReturnProduct(productToReturn, marketplace);
                        break;
                    case "4":
                        var productToFavorite = CustomerActions.PickProductFromMarketplace(customer, marketplace);
                        customer.AddProductToFavorite(productToFavorite);
                        break;
                    case "5":
                        customer.PrintBoughtProducts();
                        break;
                    case "6":
                        customer.PrintFavouriteProducts();
                        break;
                    case "7":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Krivi unos, unesi ponovno!");
                        break;
                }
            }
        }
    }
}
