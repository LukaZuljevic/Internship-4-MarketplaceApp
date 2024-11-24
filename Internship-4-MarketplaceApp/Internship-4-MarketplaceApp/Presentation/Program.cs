using Internship_4_MarketplaceApp.Data.Enum;
using Internship_4_MarketplaceApp.Domain.Classes;
using Internship_4_MarketplaceApp.Domain.Classes.Users;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Sources;

namespace Internship_4_MarketplaceApp.Presentation
{
    public class Program
    {
        static Marketplace marketplace = new Marketplace();
        static Customer testCustomer1 = new Customer("Ante", "Ante@gmail.com", 100);
        static Salesman testSalesman1 = new Salesman("Mile", "Mile@gmail.com");
        static Salesman testSalesman2 = new Salesman("Mijo", "Mijo@outlook.com");
        static Salesman testSalesman3 = new Salesman("Miki", "Miki@fesb.com");

        static void Main(string[] args)
        {
            marketplace.AddNewUser(testSalesman1);
            marketplace.AddNewUser(testSalesman2);
            marketplace.AddNewUser(testSalesman3);

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
                        UserLogin();
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

        static void UserRegistration()
        {
            Console.Clear();
            Console.WriteLine("Registracija korisnika:\n");

            var userName = CheckIfValidString("ime", "korisnika");
            var userEmail = CheckIfValidEmail();

            if (marketplace.Users.Any(user => user.Email == userEmail))
            {
                Console.WriteLine("Korisnik s tim email-om već postoji.");
                return;
            }

            var userType = GetUserType();

            if(userType == UserType.Customer)
            {
                var customerBalance = CheckIfValidBalance();
                Customer newCustomer = new Customer(userName, userEmail, customerBalance);

                marketplace.AddNewUser(newCustomer);
            }
            else
            {
                Salesman newSalesman = new Salesman(userName, userEmail);

                marketplace.AddNewUser(newSalesman);
            }
            Console.WriteLine("Uspjesna registracija!");

            UserLogin();
        }

        static void UserLogin()
        {
            Console.Clear();
            Console.WriteLine("Prijava korisnika:\n");

            var userEmail = CheckIfValidEmail();

            var matchingUser = marketplace.Users.FirstOrDefault(user => user.Email == userEmail);

            if (matchingUser != null)
            {
                if (matchingUser is Customer)
                {
                    // CustomerMenu();
                }
                else if (matchingUser is Salesman salesman)
                {
                    SalesmanMenu(salesman);
                }
            }
            else
            {
                Console.WriteLine("Ne postoji korisnik s tim email-om!\n");
            }
        }

        static void SalesmanMenu(Salesman salesman)
        {
            Console.Clear();
            Console.WriteLine("Dobrodosli u prostor za prodavaca\n");

            while (true)
            {
                Console.WriteLine("1 - Dodaj proizvod\n2 - Pregledaj sve svoje proizvode\n3 - Pregledaj svoju ukupnu zaradu\n4 - Pregledaj prodane proizvode po kategoriji\n5 - Pregledaj svoju ukupnu zaradu u odredenom razdoblju\n6 - Vrati se nazad na pocetni menu");
                var userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        AddProductToSell(salesman);
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Krivi unos, unesi ponovno!");
                        break;
                }
            }
        }

        static void AddProductToSell(Salesman salesman)
        {
            var productName = CheckIfValidString("ime", "proizvoda");
            var productDescription = CheckIfValidString("opis", "proizvoda");
            var productPrice = CheckIfValidPrice();
            var productType = PickProductType();

            Product newProduct = new Product(productName, productDescription, productPrice, Status.Na_prodaju, salesman, ProductType.Odjeca);

            salesman.AddNewProduct(newProduct);
            marketplace.AddNewProduct(newProduct);
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
                    Console.WriteLine("Ne smije biti empty string!\n");
                    continue;
                }
                else if (!input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("Smijes unit samo slova!\n");
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
                    Console.WriteLine("Ne smije biti empty string!\n");
                    continue;
                }

                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; //straight from google
                if (Regex.IsMatch(emailInput, emailPattern))
                {
                    return emailInput;
                }
                else
                {
                    Console.WriteLine("Unesi validan email!\n");
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
                    Console.WriteLine("Krivi unos, unesi ponovno!\n");
                }
            }
        }

        static double CheckIfValidPrice()
        {
            double priceInput = 0;

            while (true)
            {
                Console.Write("Unesi cijenu proizvoda: ");

                if (double.TryParse(Console.ReadLine(), out priceInput) && priceInput >= 0)
                {
                    return priceInput;
                }
                else
                {
                    Console.WriteLine("Krivi unos, unesi ponovno!\n");
                }
            }
        }

        static Enum PickProductType()
        {
            Console.Clear();
            Console.WriteLine("Odaberite kategoriju proizvoda:\n");

            foreach (var category in Enum.GetValues(typeof(ProductType)))
            {
                Console.WriteLine($"{(int)category} - {category}");
            }

            while (true)
            {
                Console.Write("\nUnesite broj kategorije: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int selectedCategory) &&
                    Enum.IsDefined(typeof(ProductType), selectedCategory))
                {
                    return (ProductType)selectedCategory;
                }

                Console.WriteLine("Krivi unos, unesi ponovno!\n");
            }
        }
    }
}
