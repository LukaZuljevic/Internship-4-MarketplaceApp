using Internship_4_MarketplaceApp.Data.Enum;
using Internship_4_MarketplaceApp.Domain.Classes.Users;

namespace Internship_4_MarketplaceApp.Domain.Classes
{
    public class Transaction
    {
        public static int Counter = 1;
        public int Id { get; }
        public Customer Customer { get; set; }
        public Salesman Salesman { get; set; }
        public DateTime DateOfTransaction { get; private set; }
        public TransactionType TransactionType { get; set; }
        public Product Product { get; set; }

        public Transaction(Customer customer, Salesman salesman, DateTime dateOfTransaction, TransactionType transactionType, Product product)
        {
            Id = Counter++;
            Customer = customer;
            Salesman = salesman;
            DateOfTransaction = dateOfTransaction;
            TransactionType = transactionType;
            Product = product;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Kupac: {Customer.Name}, Prodavac: {Salesman.Name}, Proizvid: {Product}, Datum: {DateOfTransaction}, Tip: {TransactionType}";
        }
    }
}
