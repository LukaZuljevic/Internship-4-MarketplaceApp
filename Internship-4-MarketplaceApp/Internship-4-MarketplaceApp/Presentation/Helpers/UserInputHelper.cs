using Internship_4_MarketplaceApp.Data.Enum;
using System.Text.RegularExpressions;
using Internship_4_MarketplaceApp.Domain.Classes.Users;
using System.Globalization;

namespace Internship_4_MarketplaceApp.Presentation.Helpers
{
    public static class UserInputHelper
    {
        public static string CheckIfValidString(string attribute, string entity)
        {
            while (true)
            {
                Console.Write($"Unesi {attribute} {entity}: ");
                var input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ne smije biti prazan unos!\n");
                }
                else if (!input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("Samo su slova dopustena!\n");
                }
                else if (input.Length > 20)
                {
                    Console.WriteLine("Unos mora biti kraci od 20 znakova!\n");
                }
                else if (input.Length < 3)
                {
                    Console.WriteLine("Unos mora biti duzi od 2 znaka!\n");
                }
                else
                {
                    return input;
                }
            }
        }

        public static string CheckIfValidEmail()
        {
            var emailInput = string.Empty;

            while (true)
            {
                Console.Write("Unesi email korisnika(Enter za prekid unosa): ");
                emailInput = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(emailInput))
                {
                    Console.WriteLine("Otkazan unos!\n");
                    return null;
                }

                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (Regex.IsMatch(emailInput, emailPattern))
                {
                    return emailInput;
                }
                else
                {
                    Console.WriteLine("Unesi validan email.\n");
                    continue;
                }
            }
        }

        public static double CheckIfValidNumber(string prompt)
        {
            double input = 0;

            while (true)
            {
                Console.Write(prompt);

                if (double.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Krivi unos, unesi broj veci od 0!\n");
                }
            }
        }

        public static UserType GetUserType()
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
                    Console.WriteLine("Krivi unos, unesi ponovno!\n");
                }
            }
        }

        public static ProductType PickProductType()
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

                Console.WriteLine("Krivi unos, unesi jednu od ponudenih opcija!\n");
            }
        }

        public static DateTime CheckDate(string typeOfDate)
        {
            DateTime dateOutput;

            while (true)
            {
                Console.Write($"Unesi datum {typeOfDate} perioda(yyyy-MM-dd): ");
                var input = Console.ReadLine();

                if (!DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOutput))
                {
                    Console.WriteLine("Krivi unos, unesi datum u formatu (yyyy-MM-dd)!");
                    continue;
                }

                break;
            }

            return dateOutput;
        }

        public static int CheckIfValidId(Salesman salesman)
        {
            while (true)
            {
                Console.Write("\nOdaberi Id jednog od proizvoda na listi: ");
                var pickedProductId = Console.ReadLine();

                if (int.TryParse(pickedProductId, out int productId))
                {
                    if (salesman.ListOfProducts.FirstOrDefault(p => p.Id == productId) != null)
                        return productId;
                    else
                        Console.WriteLine("Proizvod s tim Id-em ne postoji!");
                }
                else
                {
                    Console.WriteLine("Krivi unos, Id mora bit broj.");
                }
            }

        }

        public static double CheckIfValidPrice()
        {
            double priceInput = 0;

            while (true)
            {
                Console.Write("Unesi cijenu proizvoda(eur): ");

                if (double.TryParse(Console.ReadLine(), out priceInput) && priceInput > 0)
                {
                    return priceInput;
                }
                else
                {
                    Console.WriteLine("Krivi unos, cijena mora biti veca od 0!\n");
                }
            }
        }

    }
}
