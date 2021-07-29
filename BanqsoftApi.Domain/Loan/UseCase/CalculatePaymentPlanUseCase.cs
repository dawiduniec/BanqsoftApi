using System.Collections.Generic;
using BanqsoftApi.Domain.Loan.Entity;

namespace BanqsoftApi.Domain.Loan.UseCase
{
    public class CalculatePaymentPlanUseCase
    {

        private Entity.Loan _loan;

        public CalculatePaymentPlanUseCase ForLoan(Entity.Loan loan)
        {
            _loan = loan;
            return this;
        }

        public LoanPaymentPlan Run()
        {
            var result = new LoanPaymentPlan
            {
                MonthlyLoanRates = new List<MonthlyLoanRate>(_loan.NumberOfPayments)
            };

            var balance = _loan.Amount;
            var interestBalance = 0m;
            var interestRateMonthly = _loan.InterestRate / 100 / 12;

            for (int i = 1; i <= _loan.NumberOfPayments; i++)
            {
                var interest = decimal.Round(balance * (decimal)interestRateMonthly, 2);
                var principal = decimal.Round(_loan.MonthlyRate - interest, 2);
                balance -= principal;
                interestBalance += interest;
                var paymentAmount = _loan.MonthlyRate;

                if (i == _loan.NumberOfPayments)
                {
                    principal += balance;
                    paymentAmount += balance;
                    balance = 0;
                }

                result.MonthlyLoanRates.Add(new MonthlyLoanRate
                {
                    Index = i,
                    Interest = interest,
                    Principal = principal,
                    Balance = balance, 
                    TotalInterest = interestBalance, 
                    PaymentAmount = paymentAmount
                });
            }

            return result;
        }
    }
}
