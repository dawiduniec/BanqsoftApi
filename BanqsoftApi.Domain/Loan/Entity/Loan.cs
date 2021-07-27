namespace BanqsoftApi.Domain.Loan.Entity
{
    public class Loan
    {
        public int NumberOfPayments { get; set; }
        public decimal MonthlyRate { get; set; }
        public decimal Amount { get; set; }
        public double InterestRate { get; set; }
    }
}
