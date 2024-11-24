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
        static Product testProduct1 = new Product("Banana", "Ovo je banana", 2, Status.Na_prodaju, testSalesman1, ProductType.Hrana);
        static Product testProduct2 = new Product("Laptop", "Gaming laptop", 1200, Status.Na_prodaju, testSalesman2, ProductType.Elektronika);
        static Product testProduct3 = new Product("Pametni mobitel", "Iphone 1", 800, Status.Na_prodaju, testSalesman3, ProductType.Elektronika);
        static Product testProduct4 = new Product("Majica", "Pamucna majica", 15, Status.Na_prodaju, testSalesman1, ProductType.Odjeca);
        static Product testProduct5 = new Product("Jaketa", "Topla jaketa", 80, Status.Na_prodaju, testSalesman2, ProductType.Odjeca);
        static Product testProduct6 = new Product("Jabuka", "Ovo ti je jabuka", 1, Status.Na_prodaju, testSalesman3, ProductType.Hrana);
        static Product testProduct7 = new Product("Cokolada", "Cokolada sa ljesnjacima", 3, Status.Na_prodaju, testSalesman1, ProductType.Hrana);

        static void Main(string[] args)
        {
            marketplace.AddNewUser(testSalesman1);
            marketplace.AddNewUser(testSalesman2);
            marketplace.AddNewUser(testSalesman3);
            marketplace.AddNewUser(testCustomer1);

            marketplace.AddNewProduct(testProduct1);
            marketplace.AddNewProduct(testProduct4);
            marketplace.AddNewProduct(testProduct2);
            marketplace.AddNewProduct(testProduct3);
            marketplace.AddNewProduct(testProduct5);
            marketplace.AddNewProduct(testProduct6);
            marketplace.AddNewProduct(testProduct7);

            testSalesman1.AddNewProduct(testProduct1);
            testSalesman1.AddNewProduct(testProduct4);
            testSalesman2.AddNewProduct(testProduct2);
            testSalesman3.AddNewProduct(testProduct3);
            testSalesman2.AddNewProduct(testProduct5);
            testSalesman3.AddNewProduct(testProduct6);
            testSalesman1.AddNewProduct(testProduct7);

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
                if (matchingUser is Customer customer)
                {
                    CustomerMenu(customer);
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
                        salesman.PrintAllProducts();
                        break;
                    case "3":
                        var totalEarnings = salesman.CalculateEarnings();
                        Console.WriteLine($"Ukupna zarada: {totalEarnings}\n");
                        break;
                    case "4":
                        var productCategory = PickProductType();
                        salesman.ProductByCategory(productCategory);
                        break;
                    case "5":
                        //napravi ovo!
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

        static void CustomerMenu(Customer customer)
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
                        break;
                    case "2":
                        var productToBuy = PickProductToBuy(customer);
                        marketplace.SellProduct(productToBuy, customer);
                        break;
                    case "3":
                        var productToReturn = PickProductToReturn(customer);
                        marketplace.ReturnProduct(productToReturn, customer);
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
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

        static Product PickProductToBuy(Customer customer)
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
                        Console.WriteLine("Proizvod s tim Id-em ne postoji!");
                }
                else
                {
                    Console.WriteLine("Krivi unos, Id mora bit broj.");
                }
            }

            return selectedProduct;
        }

        static Product PickProductToReturn(Customer customer)
        {
            Console.Clear();
            customer.PrintBoughtProducts();

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
                Console.Write("Unesi cijenu proizvoda(eur): ");

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

        static ProductType PickProductType()
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
