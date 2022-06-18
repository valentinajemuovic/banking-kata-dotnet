using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure;
using Optivem.Kata.Banking.Infrastructure.Persistence;
using Optivem.Kata.Banking.Test.Common.Builders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure
{
    public class BankAccountRepositoryTest : IDisposable
    {
        private readonly DatabaseContext _dbContext;
        private readonly BankAccountRepository _repository;
        private readonly AccountNumberGenerator _accountNumberGenerator;

        public BankAccountRepositoryTest()
        {
            // TODO: VC: Move to DI container and then use from DI, similarly for context disposal
            var connectionString = "Data Source=localhost;Initial Catalog=BankingKata;Integrated Security=True;MultipleActiveResultSets=True;";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(connectionString);

            _dbContext = new DatabaseContext(optionsBuilder.Options);
            _repository = new BankAccountRepository(_dbContext);
            _accountNumberGenerator = new AccountNumberGenerator();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
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
