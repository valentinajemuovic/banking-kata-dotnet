using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using static Optivem.Kata.Banking.Test.Common.Builders.Entities.BankAccountBuilder;

namespace Optivem.Kata.Banking.Test.Infrastructure.Fake
{
    public class FakeBankAccountRepositoryTest
    {
        private readonly IBankAccountRepository _repository;

        public FakeBankAccountRepositoryTest()
        {
            _repository = new FakeBankAccountRepository();
        }

        [Fact]
        public async Task Should_return_empty_result_when_account_number_does_not_exist()
        {
            var accountNumber = "GB36BARC20038032622823";

            await _repository.ShouldNotContainAsync(accountNumber);
        }

        [Fact]
        public async Task Should_return_bank_account_when_account_number_exists()
        {
            var accountNumber = "GB36BARC20038032622823";
            var bankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Build();

            _repository.Add(bankAccount);

            await _repository.ShouldContainAsync(bankAccount);
        }

        [Fact]
        public async Task Should_retrieve_updated_bank_account_after_update()
        {
            var accountNumber = "GB36BARC20038032622823";
            var initialBalance = 40;
            var withdrawalAmount = 10;
            var finalBalance = 30;

            var initialBankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Balance(initialBalance)
                    .Build();

            var expectedFinalBankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Balance(finalBalance)
                    .Build();

            _repository.Add(initialBankAccount);

            initialBankAccount.Withdraw(Money.From(withdrawalAmount));

            _repository.Update(initialBankAccount);

            await _repository.ShouldContainAsync(expectedFinalBankAccount);
        }

        [Fact]
        public async Task Should_not_be_able_to_change_bank_account_after_add()
        {
            var accountNumber = "GB36BARC20038032622823";
            var balance = 40;
            var withdrawalAmount = 10;

            var initialBankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Balance(balance)
                    .Build();

            var expectedFinalBankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Balance(balance)
                    .Build();

            _repository.Add(initialBankAccount);

            initialBankAccount.Withdraw(Money.From(withdrawalAmount));

            await _repository.ShouldContainAsync(expectedFinalBankAccount);
        }

        [Fact]
        public async Task Should_not_be_able_to_change_bank_account_after_find()
        {
            var accountNumber = "GB36BARC20038032622823";
            var balance = 40;
            var withdrawalAmount = 10;

            var bankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Balance(balance)
                    .Build();

            var expectedBankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Balance(balance)
                    .Build();

            _repository.Add(bankAccount);

            var retrievedBankAccount = await _repository.GetByAccountNumberAsync(AccountNumber.From(accountNumber));

            retrievedBankAccount.Should().NotBeNull();

            retrievedBankAccount.Withdraw(Money.From(withdrawalAmount));

            await _repository.ShouldContainAsync(expectedBankAccount);
        }

        [Fact]
        public async Task Should_not_be_able_to_change_bank_account_after_update()
        {
            var accountNumber = "GB36BARC20038032622823";
            var balance = 40;
            var withdrawalAmount = 10;

            var bankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Balance(balance)
                    .Build();

            var expectedBankAccount = BankAccount()
                    .AccountNumber(accountNumber)
                    .Balance(balance)
                    .Build();

            _repository.Add(bankAccount);

            var retrievedBankAccount = await _repository.GetByAccountNumberAsync(AccountNumber.From(accountNumber));

            retrievedBankAccount.Should().NotBeNull();

            _repository.Update(retrievedBankAccount);

            retrievedBankAccount.Withdraw(Money.From(withdrawalAmount));

            await _repository.ShouldContainAsync(expectedBankAccount);
        }

    }
}
