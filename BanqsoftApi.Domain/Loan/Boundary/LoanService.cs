using BanqsoftApi.Domain.Loan.LoanCalculationAlgorithm;
using BanqsoftApi.Domain.Loan.UseCase;

namespace BanqsoftApi.Domain.Loan.Boundary
{
    public class LoanService
    {
        private readonly CalculateLoanUseCase _calculateLoanUse;
        private readonly CalculatePaymentPlanUseCase _calculatePaymentPlanUseCase;

        public LoanService(CalculateLoanUseCase calculateLoanUse, CalculatePaymentPlanUseCase calculatePaymentPlanUseCase)
        {
            _calculateLoanUse = calculateLoanUse;
            _calculatePaymentPlanUseCase = calculatePaymentPlanUseCase;
        }

        public Entity.Loan CalculateHousingLoan(in decimal amount, in int numberOfYears)
        {
            var loan = _calculateLoanUse
                .ForAmount(amount)
                .ForNumberOfYears(numberOfYears)
                .WithAlgorithm(new HousingFixedRateLoanAlgorithm())
                .Run();

            return loan;
        }

        public Entity.LoanPaymentPlan CalculatePaymentPlan(Entity.Loan loan)
        {
            return _calculatePaymentPlanUseCase
                .ForLoan(loan)
                .Run();
        }
    }
}
