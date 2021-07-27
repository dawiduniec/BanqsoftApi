using System;
using BanqsoftApi.Domain.Loan.LoanCalculationAlgorithm;
using NUnit.Framework;

namespace BanqsoftApi.DomainTests.Loan.LoanCalculationAlgorithm
{
    public class HousingLoanAlgorithmTests
    {
        public HousingFixedRateLoanAlgorithm _target;

        [SetUp]
        public void Setup()
        {
            _target = new HousingFixedRateLoanAlgorithm();
        }

        [TestCase(1200, 1, 101.71, 12)]
        [TestCase(1234, 5, 22.26, 60)]
        [TestCase(123400000, 10, 1200122.85, 120)]
        public void WhenCalculatingLoanForFixedPrice_ShouldReturnValidData(decimal loanAmount, int numberOfYears,
            decimal monthlyRate, int numberOfPayments)
        {
            // Act
            var result = _target.Calculate(loanAmount, numberOfYears);

            // Assert
            Assert.AreEqual(result.MonthlyRate, monthlyRate);
            Assert.AreEqual(result.NumberOfPayments, numberOfPayments);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void WhenCalculatingLoanForNotPositiveAmount_ShouldThrowException(decimal amount)
        {
            // Arrange
            const int numberOfYears = 123;

            // Act && Arrange
            Assert.Throws<ArgumentException>(() => _target.Calculate(amount, numberOfYears));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void WhenCalculatingLoanForNotPositiveNumberOfYears_ShouldThrowException(int numberOfYears)
        {
            // Arrange
            const decimal amount = 123;

            // Act && Arrange
            Assert.Throws<ArgumentException>(() => _target.Calculate(amount, numberOfYears));
        }
    }
}
