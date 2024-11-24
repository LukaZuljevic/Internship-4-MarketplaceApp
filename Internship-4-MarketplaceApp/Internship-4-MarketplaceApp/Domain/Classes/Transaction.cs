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

        public Transaction(Customer customer, Salesman salesman, DateTime dateOfTransaction, TransactionType transactionType)
        {
            Id = Counter++;
            Customer = customer;
            Salesman = salesman;
            DateOfTransaction = dateOfTransaction;
            TransactionType = transactionType;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Kupac: {Customer.Name}, Prodavac: {Salesman.Name}, Datum: {DateOfTransaction}, Tip: {TransactionType}";
        }
    }
}
