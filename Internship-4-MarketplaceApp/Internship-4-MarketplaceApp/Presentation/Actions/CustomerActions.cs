using Internship_4_MarketplaceApp.Domain.Classes.Users;
using Internship_4_MarketplaceApp.Domain.Classes;

namespace Internship_4_MarketplaceApp.Presentation.Actions
{
    public class CustomerActions
    {
        public static Product PickProductFromMarketplace(Customer customer, Marketplace marketplace)
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

        public static Product PickProductToReturn(Customer customer)
        {
            Console.Clear();
            customer.PrintBoughtProducts();

            if (customer.BoughtProducts.Count == 0)
                return null;

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

        public static double UseCoupon(Product product, Marketplace marketplace)
        {
            Console.Clear();
            marketplace.PrintCoupons();

            while (true)
            {
                Console.Write("Unesi kupon(ako ne zelis kupon ili ako kupon za tu kateogoriju ne postoji stisni enter): ");
                var couponName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(couponName))
                    return product.Price;

                Coupon coupon = marketplace.ListOfCoupons.FirstOrDefault(c => c.CouponCode == couponName && c.ProductType == product.ProductType && c.ExpirationDate > DateTime.Now);

                if (coupon == null)
                {
                    Console.WriteLine("Kupon ne postoji, ne vrijedi za kategoriju tvog proizvoda ili mu je istekao rok!\n");
                }
                else
                {
                    Console.WriteLine("Kupon uspjesno iskoristen!\n");
                    return (product.Price - product.Price * coupon.PercentageOffPrice);
                }
            }
        }
    }
}
