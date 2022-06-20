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
        private readonly IAccountNumberGenerator _accountNumberGenerator;

        public BankAccountRepositoryTest(HostFixture fixture) : base(fixture)
        {
            _repository = GetService<IBankAccountRepository>();
            _accountNumberGenerator = GetService<IAccountNumberGenerator>();
        }

        [Fact]
        public async Task Should_return_null_given_non_existent_account_number()
        {
            var accountNumber = AccountNumber.From(BankAccountDefaults.DefaultAccountNumber);

            // TODO: VC: Refactor name
            var bankAccount = await _repository.GetByAccountNumberAsync(accountNumber);

            bankAccount.Should().BeNull();
        }

        [Fact(Skip = "In progress")]
        public async Task Should_retrieve_added_bank_account()
        {
            var accountNumber = _accountNumberGenerator.Next();
            var bankAccount = BankAccountTestBuilder.BankAccount()
                .WithAccountNumber(accountNumber.Value) // TODO: VC: Refactor with common builder
                .Build();

            _repository.Add(bankAccount);

            var retrievedBankAccount = await _repository.GetByAccountNumberAsync(accountNumber);

            retrievedBankAccount.Should().BeEquivalentTo(bankAccount);
        }


    }
}
