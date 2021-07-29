namespace BanqsoftApi.Domain.Loan.Entity
{
    public class MonthlyLoanRate
    {
        public int Index { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal Balance { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}