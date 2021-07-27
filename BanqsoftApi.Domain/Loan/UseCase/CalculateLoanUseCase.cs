using BanqsoftApi.Domain.Loan.LoanCalculationAlgorithm;

namespace BanqsoftApi.Domain.Loan.UseCase
{
    public class CalculateLoanUseCase
    {
        private ILoanCalculationAlgorithm _fixedRateLoanCalculationAlgorithm;
        private int _numberOfYears;
        private decimal _amount;

        public CalculateLoanUseCase WithAlgorithm(ILoanCalculationAlgorithm fixedRateLoanAlgorithm)
        {
            _fixedRateLoanCalculationAlgorithm = fixedRateLoanAlgorithm;
            return this;
        }

        public CalculateLoanUseCase ForAmount(decimal amount)
        {
            _amount = amount;
            return this;
        }

        public CalculateLoanUseCase ForNumberOfYears(int numberOfYears)
        {
            _numberOfYears = numberOfYears;
            return this;
        }

        public Entity.Loan Run()
        {
            return _fixedRateLoanCalculationAlgorithm.Calculate(_amount, _numberOfYears);
        }
    }
}
