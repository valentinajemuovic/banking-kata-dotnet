using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure;
using Optivem.Kata.Banking.Test.Common.Builders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure
{
    public class BankAccountRepositoryTest
    {
        private readonly BankAccountRepository _repository;

        public BankAccountRepositoryTest()
        {
            _repository = new BankAccountRepository();
        }

        [Fact]
        public async Task Should_return_null_given_non_existent_account_number()
        {
            var accountNumber = AccountNumber.From(BankAccountDefaults.DefaultAccountNumber);

            // TODO: VC: Refactor name
            var bankAccount = await _repository.GetByAccountNumberAsync(accountNumber);

            bankAccount.Should().BeNull();
        } 
    }
}
