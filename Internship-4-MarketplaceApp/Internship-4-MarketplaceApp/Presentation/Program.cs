using Internship_4_MarketplaceApp.Data.Enum;
using Internship_4_MarketplaceApp.Domain.Classes;
using Internship_4_MarketplaceApp.Domain.Classes.Users;
using System;
using System.Text.RegularExpressions;

namespace Internship_4_MarketplaceApp.Presentation
{
    public class Program
    {
        static Marketplace marketplace = new Marketplace();
        static Customer testCustomer1 = new Customer("Ante", "Ante@gmail.com", 100);
        static Salesman testSalesman1 = new Salesman("Mile", "Mile@gmail.com");

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Registracija\n2 - Prijava\n3 - Izlaz iz aplikacije");
                var userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        UserRegistration();
                        break;
                    case "2":
                        //UserLogin();
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Krivi unos, unesi ponovno!");
                        break;
                }
            }
        }

        static void UserRegistration()
        {
            var userName = CheckIfValidString("ime", "korisnika");
            var userEmail = CheckIfValidEmail();
            var userType = GetUserType();

            if(userType == UserType.Customer)
            {
                var customerBalance = CheckIfValidBalance();
                Customer newCustomer = new Customer(userName, userEmail, customerBalance);

                marketplace.AddNewUser(newCustomer);

                Console.WriteLine("Uspjena registracija!");
            }
            else
            {
                Salesman newSalesman = new Salesman(userName, userEmail);

                marketplace.AddNewUser(newSalesman);

                Console.WriteLine("Uspjena registracija!");
            }

            //UserLogin();
        }

        static string CheckIfValidString(string attribute, string entity)
        {
            var input = string.Empty;

            while (true)
            {
                Console.Write($"Unesi {attribute} {entity}: ");
                input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Ne smije biti empty string! ");
                    continue;
                }
                else if (!input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("Smijes unit samo slova!");
                    continue;
                }

                break;
            }

            return input;
        }

        static string CheckIfValidEmail()
        {
            var emailInput = string.Empty;

            while (true)
            {
                Console.Write("Unesi email korisnika: ");
                emailInput = Console.ReadLine();

                if (string.IsNullOrEmpty(emailInput))
                {
                    Console.WriteLine("Ne smije biti empty string! ");
                    continue;
                }

                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; //straight from google
                if (Regex.IsMatch(emailInput, emailPattern))
                {
                    return emailInput;
                }
                else
                {
                    Console.WriteLine("Unesi validan email!");
                    continue;
                }
            }
        }

        static UserType GetUserType()
        {
            while (true)
            {
                Console.WriteLine("Odaberite tip korisnika:");
                Console.WriteLine("1 - Kupac\n2 - Prodavac");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    return UserType.Customer;
                }
                else if (input == "2")
                {
                    return UserType.Salesman;
                }
                else
                {
                    Console.WriteLine("Krivi unos, unesi ponovno!");
                }
            }
        }

        static double CheckIfValidBalance()
        {
            double balanceInput = 0;

            while (true)
            {
                Console.Write("Unesi pocetni budzet kupca: ");

                if (double.TryParse(Console.ReadLine(), out balanceInput) && balanceInput >= 0)
                {
                    return balanceInput;
                }
                else
                {
                    Console.WriteLine("Krivi unos, unesi ponovno!");
                }
            }
        }
    }
}
