namespace BanqsoftApi.Domain.Loan.LoanCalculationAlgorithm
{
    public interface ILoanCalculationAlgorithm
    {
        Entity.Loan Calculate(in decimal loanAmount, in int numberOfYears);
    }
}
