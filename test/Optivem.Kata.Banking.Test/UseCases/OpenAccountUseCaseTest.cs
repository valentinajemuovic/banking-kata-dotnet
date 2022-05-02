using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.OpenAccount;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Generators;
using Optivem.Kata.Banking.Test.Common.Data;
using Optivem.Kata.Banking.Test.Common.Givens;
using Optivem.Kata.Banking.Test.Common.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using static Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders.OpenAccountRequestBuilder;

namespace Optivem.Kata.Banking.Test.UseCases
{
    public class OpenAccountUseCaseTest
    {
        private readonly FakeAccountNumberGenerator _accountNumberGenerator;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly OpenAccountUseCase _useCase;

        public OpenAccountUseCaseTest()
        {
            _accountNumberGenerator = new FakeAccountNumberGenerator();
            _bankAccountRepository = new FakeBankAccountRepository();
            _useCase = new OpenAccountUseCase(_accountNumberGenerator, _bankAccountRepository);
        }

        [Theory]
        [InlineData("John", "Smith", 0, "GB41OMQP68570038161775")]
        [InlineData("Mary", "McDonald", 50, "GB36BMFK75394735916876")]
        public async Task Should_open_account_given_valid_request(string firstName, string lastName, int balance, string accountNumber)
        {
            _accountNumberGenerator.WillGenerate(accountNumber);

            var request = OpenAccount()
                .FirstName(firstName)
                .LastName(lastName)
                .Balance(balance)
                .Build();

            var expectedResponse = new OpenAccountResponse
            {
                AccountNumber = accountNumber,
            };

            var response = await _useCase.HandleAsync(request);

            response.Should().BeEquivalentTo(expectedResponse);

            await _bankAccountRepository.ShouldContainAsync(accountNumber, firstName, lastName, balance);
        }

        [Theory]
        [ClassData(typeof(NullEmptyWhitespaceStringData))]
        public async Task Should_throw_exception_given_empty_first_name(string firstName)
        {
            var request = OpenAccount().FirstName(firstName).Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.FirstNameEmpty);
        }

        [Theory]
        [ClassData(typeof(NullEmptyWhitespaceStringData))]
        public async Task Should_throw_exception_given_empty_last_name(string lastName)
        {
            var request = OpenAccount().LastName(lastName).Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.LastNameEmpty);
        }

        [Theory]
        [ClassData(typeof(NegativeIntData))]
        public async Task Should_throw_exception_given_negative_initial_balance(int balance)
        {
            var request = OpenAccount().Balance(balance).Build();

            Func<Task> action = () => _useCase.HandleAsync(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.BalanceNegative);
        }
    }
}
