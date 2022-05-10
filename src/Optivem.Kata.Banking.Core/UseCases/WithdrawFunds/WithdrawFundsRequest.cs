namespace Optivem.Kata.Banking.Core.UseCases.WithdrawFunds
{
    public class WithdrawFundsRequest
    {
        public string? AccountNumber { get; set; }
        public int Amount { get; set; }
    }
}