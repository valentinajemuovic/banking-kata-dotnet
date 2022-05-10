namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public interface IAccountNumberGenerator
    {
        AccountNumber Next();
    }
}