using System.Collections.Generic;
using BanqsoftApi.Domain.Loan.Entity;

namespace BanqsoftApi.Models
{
    public class LoanResponse
    {
        public Loan Loan { get; set; }
        public ICollection<MonthlyLoanRate> MonthlyLoanRates { get; set; }
    }
}
