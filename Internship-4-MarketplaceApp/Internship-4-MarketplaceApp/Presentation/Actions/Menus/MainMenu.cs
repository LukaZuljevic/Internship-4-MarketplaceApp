using Internship_4_MarketplaceApp.Domain.Classes;
using Internship_4_MarketplaceApp.Presentation.Actions.HomePage;

namespace Internship_4_MarketplaceApp.Presentation.Actions.Menus
{
    internal class MainMenu
    {
        public void DisplayMainMenu(Marketplace marketplace)
        {
            while (true)
            {
                Console.WriteLine("1 - Registracija\n2 - Prijava\n3 - Izlaz iz aplikacije");
                var userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        Register.DisplayRegistration(marketplace);
                        break;
                    case "2":
                        Login.DisplayLogin(marketplace);
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Krivi unos, unesi ponovno!\n");
                        break;
                }
            }
        }
    }
}
