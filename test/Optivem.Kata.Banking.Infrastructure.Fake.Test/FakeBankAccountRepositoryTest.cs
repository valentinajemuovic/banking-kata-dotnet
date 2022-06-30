using System;
using System.Threading.Tasks;
using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Verification;
using Xunit;
using static Optivem.Kata.Banking.Test.Common.Builders.Entities.BankAccountTestBuilder;

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
                .WithAccountNumber(accountNumber)
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
                .WithAccountNumber(accountNumber)
                .WithBalance(initialBalance)
                .Build();

            var expectedFinalBankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(finalBalance)
                .Build();

            _repository.Add(initialBankAccount);

            initialBankAccount.Withdraw(TransactionAmount.From(withdrawalAmount));

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
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            var expectedFinalBankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            _repository.Add(initialBankAccount);

            initialBankAccount.Withdraw(TransactionAmount.From(withdrawalAmount));

            await _repository.ShouldContainAsync(expectedFinalBankAccount);
        }

        [Fact]
        public async Task Should_not_be_able_to_change_bank_account_after_find()
        {
            var accountNumber = "GB36BARC20038032622823";
            var balance = 40;
            var withdrawalAmount = 10;

            var bankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            var expectedBankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            _repository.Add(bankAccount);

            var retrievedBankAccount = await _repository.GetAsync(AccountNumber.From(accountNumber));

            retrievedBankAccount.Should().NotBeNull();

            retrievedBankAccount.Withdraw(TransactionAmount.From(withdrawalAmount));

            await _repository.ShouldContainAsync(expectedBankAccount);
        }

        [Fact]
        public async Task Should_not_be_able_to_change_bank_account_after_update()
        {
            var accountNumber = "GB36BARC20038032622823";
            var balance = 40;
            var withdrawalAmount = 10;

            var bankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            var expectedBankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            _repository.Add(bankAccount);

            var retrievedBankAccount = await _repository.GetAsync(AccountNumber.From(accountNumber));

            retrievedBankAccount.Should().NotBeNull();

            _repository.Update(retrievedBankAccount);

            retrievedBankAccount.Withdraw(TransactionAmount.From(withdrawalAmount));

            await _repository.ShouldContainAsync(expectedBankAccount);
        }

        [Fact]
        public void Should_throw_exception_when_attempt_add_bank_account_with_same_account_number_twice()
        {
            var accountNumber = "GB36BARC20038032622823";
            var balance = 40;
            var balance2 = 60;

            var bankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance)
                .Build();

            var bankAccount2 = BankAccount()
                .WithAccountNumber(accountNumber)
                .WithBalance(balance2)
                .Build();

            _repository.Add(bankAccount);

            Action action = () => _repository.Add(bankAccount2);

            action.Should().ThrowExactly<RepositoryException>()
                .WithMessage(RepositoryMessages.RepositoryConstraintValidation);
        }

        [Fact]
        public void Should_throw_exception_when_attempt_to_update_non_existent_bank_account()
        {
            var accountNumber = "GB36BARC20038032622823";

            var bankAccount = BankAccount()
                .WithAccountNumber(accountNumber)
                .Build();

            Action action = () => _repository.Update(bankAccount);

            action.Should().ThrowExactly<RepositoryException>()
                .WithMessage(RepositoryMessages.RepositoryCannotUpdateNonExistent);
        }
    }
}