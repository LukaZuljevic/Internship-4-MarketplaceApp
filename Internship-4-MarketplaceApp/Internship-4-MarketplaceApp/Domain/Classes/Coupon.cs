using Internship_4_MarketplaceApp.Data.Enum;

namespace Internship_4_MarketplaceApp.Domain.Classes
{
    public class Coupon
    {
        public ProductType ProductType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CouponCode { get; private set; }
        public double PercentageOffPrice { get; private set; }

        public Coupon(ProductType productType, DateTime expirationDate, string couponCode, double percentageOffPrice)
        {
            ProductType = productType;
            ExpirationDate = expirationDate;
            CouponCode = couponCode;
            PercentageOffPrice = percentageOffPrice;
        }

        public override string ToString()
        {
            return $"Kupon kod: {CouponCode}, Postotak: {PercentageOffPrice}, Datum isteka: {ExpirationDate}, Kategorija: {ProductType}";
        }
    }
}
