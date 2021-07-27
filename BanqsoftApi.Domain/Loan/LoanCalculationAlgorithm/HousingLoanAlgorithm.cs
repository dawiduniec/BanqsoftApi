namespace BanqsoftApi.Domain.Loan.LoanCalculationAlgorithm
{
    public class HousingFixedRateLoanAlgorithm : FixedRateLoanCalculationAlgorithm
    {
        private const double _interestRate = 3.15;

        protected override double InterestRate => _interestRate;
    }
}
