using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Domain.Classes.Users;
using Internship_4_MarketplaceApp.Data.Enum;
using Internship_4_MarketplaceApp.Domain.Classes;

namespace Internship_4_MarketplaceApp.Presentation.Actions.HomePage
{
    public class Register
    {
        public static void DisplayRegistration(Marketplace marketplace)
        {
            Console.Clear();
            Console.WriteLine("Registracija korisnika\n");

            var userName = UserInputHelper.CheckIfValidString("ime", "korisnika");
            var userEmail = UserInputHelper.CheckIfValidEmail();

            if (userEmail == null)
                return;

            if (marketplace.Users.Any(user => user.Email == userEmail))
            {
                Console.WriteLine("Korisnik s tim email-om vec postoji.");
                return;
            }

            var userType = UserInputHelper.GetUserType();

            if (userType == UserType.Customer)
            {
                var customerBalance = UserInputHelper.CheckIfValidNumber("Unesi pocetni budzet kupca: ");
                Customer newCustomer = new Customer(userName, userEmail, customerBalance);

                marketplace.AddNewUser(newCustomer);
            }
            else
            {
                Salesman newSalesman = new Salesman(userName, userEmail);

                marketplace.AddNewUser(newSalesman);
            }
            Console.WriteLine("Uspjesna registracija!");

            Login.DisplayLogin(marketplace);
        }
    }
}
