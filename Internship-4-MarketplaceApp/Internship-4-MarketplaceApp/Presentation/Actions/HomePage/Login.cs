using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Domain.Classes.Users;
using Internship_4_MarketplaceApp.Presentation.Actions.Menus;
using Internship_4_MarketplaceApp.Domain.Classes;

namespace Internship_4_MarketplaceApp.Presentation.Actions.HomePage
{
    public class Login
    {
        public static void DisplayLogin(Marketplace marketplace)
        {
            Console.Clear();
            Console.WriteLine("Prijava korisnika:\n");

            var userEmail = UserInputHelper.CheckIfValidEmail();

            if (userEmail == null)
                return;

            var matchingUser = marketplace.Users.FirstOrDefault(user => user.Email == userEmail);

            if (matchingUser != null)
            {
                if (matchingUser is Customer customer)
                {
                    CustomerMenu.DisplayCustomerMenu(customer, marketplace);
                }
                else if (matchingUser is Salesman salesman)
                {
                    SalesmanMenu.DisplaySalesmanMenu(salesman, marketplace);
                }
            }
            else
            {
                Console.WriteLine("Ne postoji korisnik s tim email-om!\n");
            }
        }
    }
}
