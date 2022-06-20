using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Builders.Entities;
using Optivem.Kata.Banking.Web.Extensions;
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
        private readonly IHost _host;

        // private readonly DatabaseContext _dbContext;
        private readonly IBankAccountRepository _repository;
        private readonly IAccountNumberGenerator _accountNumberGenerator;

        public BankAccountRepositoryTest()
        {
            var args = new string[] { };
            _host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => services.Register(hostContext.Configuration))
                .Build();

            // TODO: VC: Move to DI container and then use from DI, similarly for context disposal
            // var connectionString = "Data Source=localhost;Initial Catalog=BankingKata;Integrated Security=True;MultipleActiveResultSets=True;";
            // var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            // optionsBuilder.UseSqlServer(connectionString);

            // _dbContext = new DatabaseContext(optionsBuilder.Options);
            // _repository = new BankAccountRepository(_dbContext);

            _repository = _host.Services.GetRequiredService<IBankAccountRepository>();
            _accountNumberGenerator = _host.Services.GetRequiredService<IAccountNumberGenerator>();
        }

        public void Dispose()
        {
            // _dbContext.Dispose();
            _host.Dispose();
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
