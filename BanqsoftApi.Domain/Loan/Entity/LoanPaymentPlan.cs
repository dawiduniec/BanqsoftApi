using System.Collections.Generic;

namespace BanqsoftApi.Domain.Loan.Entity
{
    public class LoanPaymentPlan
    {
        public ICollection<MonthlyLoanRate> MonthlyLoanRates { get; set; }

    }
}
