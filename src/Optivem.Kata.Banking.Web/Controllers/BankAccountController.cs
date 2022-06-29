using MediatR;
using Microsoft.AspNetCore.Mvc;
using Optivem.Kata.Banking.Core.UseCases.OpenAccount;
using Optivem.Kata.Banking.Core.UseCases.ViewAccount;

namespace Optivem.Kata.Banking.Web.Controllers
{
    [ApiController]
    [Route("bank-accounts")]
    public class BankAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<OpenAccountResponse>> OpenAccount(OpenAccountRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(ViewAccount), new { accountNumber = response.AccountNumber }, response);
        }

        [HttpGet("{accountNumber}")]
        public async Task<ActionResult<ViewAccountResponse>> ViewAccount(string accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
