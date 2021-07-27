using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BanqsoftApi.Domain.Loan.Boundary;
using BanqsoftApi.Domain.Loan.Entity;
using BanqsoftApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BanqsoftApi.Controllers
{
    [ApiController]
    [Route("loan")]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly LoanService _loanService;

        public LoanController(ILogger<LoanController> logger, LoanService loanService)
        {
            _logger = logger;
            _loanService = loanService;
        }

        [HttpGet]
        [Route("housing/{amount}/{numberOfYears}")]
        public ActionResult<LoanResponse> Get([BindRequired]decimal amount, [BindRequired]int numberOfYears)
        {
            var loan = _loanService.CalculateHousingLoan(amount, numberOfYears);
            var payments = _loanService.CalculatePaymentPlan(loan);

            return new LoanResponse
            {
                Loan = loan,
                MonthlyLoanRates = payments.MonthlyLoanRates
            };
        }
    }
}
