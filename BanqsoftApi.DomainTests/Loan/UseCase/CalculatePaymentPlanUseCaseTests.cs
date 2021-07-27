using System.Linq;
using BanqsoftApi.Domain.Loan.UseCase;
using NUnit.Framework;

namespace BanqsoftApi.DomainTests.Loan.UseCase
{
    public class CalculatePaymentPlanUseCaseTests
    {
        private CalculatePaymentPlanUseCase _target;

        [SetUp]
        public void Setup()
        {
            _target = new CalculatePaymentPlanUseCase();
        }

        [TestCase(1200, 3.15, 101.71, 12, 20.57)]
        [TestCase(2500, 5, 47.18, 60, 330.65)]
        public void WhenCalculatingLoanForFixedPrice_ThenTotalsRateShouldBeValid(decimal amount, double interestRate, 
            decimal monthlyRate, int numberOfPayments, decimal totalInterest)
        {
            // Arrange
            var loan = new Domain.Loan.Entity.Loan
            {
                Amount = amount,
                InterestRate = interestRate,
                MonthlyRate = monthlyRate,
                NumberOfPayments = numberOfPayments
            };


            // Act
            var paymentSchedule = _target.ForLoan(loan)
                .Run();

            // Assert
            Assert.AreEqual(paymentSchedule.MonthlyLoanRates.Sum(x => x.Interest), totalInterest);
            Assert.AreEqual(paymentSchedule.MonthlyLoanRates.Sum(x => x.Principal), amount);
            Assert.AreEqual(paymentSchedule.MonthlyLoanRates.Sum(x => x.PaymentAmount), amount + totalInterest);

        }
    }
}
