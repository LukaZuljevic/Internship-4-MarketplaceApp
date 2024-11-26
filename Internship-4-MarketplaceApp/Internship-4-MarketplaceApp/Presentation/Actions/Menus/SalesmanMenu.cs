using Internship_4_MarketplaceApp.Domain.Classes.Users;
using Internship_4_MarketplaceApp.Domain.Classes;
using Internship_4_MarketplaceApp.Presentation.Helpers;

namespace Internship_4_MarketplaceApp.Presentation.Actions.Menus
{
    public class SalesmanMenu
    {
        public static void DisplaySalesmanMenu(Salesman salesman, Marketplace marketplace)
        {
            Console.Clear();
            Console.WriteLine("Dobrodosli u prostor za prodavaca\n");

            while (true)
            {
                Console.WriteLine("1 - Dodaj proizvod\n2 - Pregledaj sve svoje proizvode\n3 - Pregledaj svoju ukupnu zaradu\n4 - Pregledaj prodane proizvode po kategoriji\n5 - Pregledaj svoju ukupnu zaradu u odredenom razdoblju\n6 - Promijeni cijenu proizvoda\n7 - Vrati se nazad na pocetni menu");
                var userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        SalesmanActions.AddProductToSell(salesman, marketplace);
                        break;
                    case "2":
                        salesman.PrintAllProducts();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"Ukupna zarada korisnika {salesman.Name}: {salesman.Earnings}\n");
                        break;
                    case "4":
                        var productCategory = UserInputHelper.PickProductType();
                        salesman.ProductByCategory(productCategory);
                        break;
                    case "5":
                        SalesmanActions.EarningsInTimePeriod(salesman, marketplace);
                        break;
                    case "6":
                        SalesmanActions.ChangeProductPrice(salesman);
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
