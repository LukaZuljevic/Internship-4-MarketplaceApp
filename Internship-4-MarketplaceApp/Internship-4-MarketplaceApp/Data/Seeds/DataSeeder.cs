using Internship_4_MarketplaceApp.Data.Enum;
using Internship_4_MarketplaceApp.Domain.Classes;
using Internship_4_MarketplaceApp.Domain.Classes.Users;

namespace Internship_4_MarketplaceApp.Data.Seeds
{
    public class DataSeeder
    {
        public static void Seed(Marketplace marketplace)
        {
            Coupon testCoupon1 = new Coupon(ProductType.Elektronika, new DateTime(2024, 12, 12), "10POPUSTA", 0.1);
            Coupon testCoupon2 = new Coupon(ProductType.Odjeca, new DateTime(2022, 11, 8), "5POPUSTA", 0.05);
            Coupon testCoupon3 = new Coupon(ProductType.Hrana, new DateTime(2026, 1, 1), "20POPUSTA", 0.2);

            Customer testCustomer1 = new Customer("Ante", "Ante@gmail.com", 1500);
            Customer testCustomer2 = new Customer("Ivan", "Ivan@gmail.com", 100);
            Salesman testSalesman1 = new Salesman("Mile", "Mile@gmail.com");
            Salesman testSalesman2 = new Salesman("Mijo", "Mijo@outlook.com");
            Salesman testSalesman3 = new Salesman("Miki", "Miki@fesb.com");

            Product testProduct1 = new Product("Banana", "Ovo je banana", 2, Status.Na_prodaju, testSalesman1, ProductType.Hrana);
            Product testProduct2 = new Product("Laptop", "Gaming laptop", 1200, Status.Na_prodaju, testSalesman2, ProductType.Elektronika);
            Product testProduct3 = new Product("Pametni mobitel", "Iphone 1", 800, Status.Na_prodaju, testSalesman3, ProductType.Elektronika);
            Product testProduct4 = new Product("Majica", "Pamucna majica", 15, Status.Na_prodaju, testSalesman1, ProductType.Odjeca);
            Product testProduct5 = new Product("Jaketa", "Topla jaketa", 80, Status.Na_prodaju, testSalesman2, ProductType.Odjeca);
            Product testProduct6 = new Product("Jabuka", "Ovo ti je jabuka", 1, Status.Na_prodaju, testSalesman3, ProductType.Hrana);
            Product testProduct7 = new Product("Cokolada", "Cokolada sa ljesnjacima", 3, Status.Na_prodaju, testSalesman1, ProductType.Hrana);

            marketplace.AddNewUser(testSalesman1);
            marketplace.AddNewUser(testSalesman2);
            marketplace.AddNewUser(testSalesman3);
            marketplace.AddNewUser(testCustomer1);
            marketplace.AddNewUser(testCustomer2);

            marketplace.AddNewProduct(testProduct1);
            marketplace.AddNewProduct(testProduct4);
            marketplace.AddNewProduct(testProduct2);
            marketplace.AddNewProduct(testProduct3);
            marketplace.AddNewProduct(testProduct5);
            marketplace.AddNewProduct(testProduct6);
            marketplace.AddNewProduct(testProduct7);

            marketplace.AddNewCoupon(testCoupon1);
            marketplace.AddNewCoupon(testCoupon2);
            marketplace.AddNewCoupon(testCoupon3);

            testSalesman1.AddNewProduct(testProduct1);
            testSalesman1.AddNewProduct(testProduct4);
            testSalesman2.AddNewProduct(testProduct2);
            testSalesman3.AddNewProduct(testProduct3);
            testSalesman2.AddNewProduct(testProduct5);
            testSalesman3.AddNewProduct(testProduct6);
            testSalesman1.AddNewProduct(testProduct7);
        }
    }
}
