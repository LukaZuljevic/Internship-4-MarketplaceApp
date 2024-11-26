using Internship_4_MarketplaceApp.Data.Seeds;
using Internship_4_MarketplaceApp.Domain.Classes;
using Internship_4_MarketplaceApp.Presentation.Actions.Menus;

namespace Internship_4_MarketplaceApp.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            Marketplace marketplace = new Marketplace();

            DataSeeder.Seed(marketplace);

            mainMenu.DisplayMainMenu(marketplace);
        }
    }
}

