using MediatR;

namespace Optivem.Kata.Banking.Core.UseCases.WithdrawFunds
{
    public class WithdrawFundsRequest : IRequest<VoidResponse>
    {
        public string? AccountNumber { get; set; }
        public int Amount { get; set; }
    }
}