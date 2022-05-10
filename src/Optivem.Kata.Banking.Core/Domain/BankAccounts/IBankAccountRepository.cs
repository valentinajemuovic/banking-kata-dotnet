namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public interface IBankAccountRepository
    {
        public Task<BankAccount?> GetByAccountNumberAsync(AccountNumber accountNumber);

        public void Add(BankAccount bankAccount);
        void Update(BankAccount bankAccount);
    }
}