using System;

namespace BanqsoftApi.Domain.Loan.LoanCalculationAlgorithm
{
    public abstract class FixedRateLoanCalculationAlgorithm : ILoanCalculationAlgorithm
    {
        protected abstract double InterestRate { get; }

        public virtual Entity.Loan Calculate(in decimal loanAmount, in int numberOfYears)
        {
            if (loanAmount <= 0 || numberOfYears <= 0)
            {
                throw new ArgumentException("Loan amount and number of years must be positive numbers.");
            }

            var numberOfPayments = numberOfYears * 12;
            var interestRateMonthly = InterestRate / 100 / 12;

            var x = (decimal)Math.Pow(1 + interestRateMonthly, numberOfPayments);
            var paymentAmount = (loanAmount * x * (decimal)interestRateMonthly) / (x - 1);

            return new Entity.Loan
            {
                MonthlyRate = decimal.Round(paymentAmount, 2),
                NumberOfPayments = numberOfPayments,
                InterestRate = InterestRate,
                Amount = loanAmount
            };
        }
    }
}
