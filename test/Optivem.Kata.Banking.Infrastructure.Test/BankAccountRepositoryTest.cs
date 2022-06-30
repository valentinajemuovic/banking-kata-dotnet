using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Optivem.Kata.Banking.CompositionRoot.Extensions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Test.Common;
using Optivem.Kata.Banking.Test.Common.Builders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure
{
    public class BankAccountRepositoryTest : BaseTest
    {
        private readonly IBankAccountRepository _repository;
        private readonly IAccountIdGenerator _accountIdGenerator;
        private readonly IAccountNumberGenerator _accountNumberGenerator;

        public BankAccountRepositoryTest(HostFixture fixture) : base(fixture)
        {
            _repository = GetService<IBankAccountRepository>();
            _accountIdGenerator = GetService<IAccountIdGenerator>();
            _accountNumberGenerator = GetService<IAccountNumberGenerator>();
        }

        [Fact]
        public async Task Should_return_null_given_non_existent_account_number()
        {
            var accountNumber = AccountNumber.From(BankAccountDefaults.DefaultAccountNumber);

            var bankAccount = await _repository.GetAsync(accountNumber);

            bankAccount.Should().BeNull();
        }

        [Fact]
        public async Task Should_retrieve_added_bank_account()
        {
            var bankAccount = CreateSomeBankAccount();
            var accountNumber = bankAccount.AccountNumber;

            _repository.Add(bankAccount);

            var retrievedBankAccount = await _repository.GetAsync(accountNumber);

            retrievedBankAccount.Should().BeEquivalentTo(bankAccount);
        }

        private BankAccount CreateSomeBankAccount()
        {
            var accountId = _accountIdGenerator.Next();
            var accountNumber = _accountNumberGenerator.Next();

            return BankAccountBuilder.BankAccount()
                .WithAccountId(accountId)
                .WithAccountNumber(accountNumber)
                .WithAccountHolderName(AccountHolderName.From(BankAccountDefaults.DefaultFirstName, BankAccountDefaults.DefaultLastName))
                .WithOpeningDate(BankAccountDefaults.DefaultOpeningDate)
                .WithBalance(Balance.From(BankAccountDefaults.DefaultBalance))
                .Build();
        }

    }
}
