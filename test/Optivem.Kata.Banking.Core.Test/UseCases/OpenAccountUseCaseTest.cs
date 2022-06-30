using System;
using System.Threading.Tasks;
using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Exceptions;
using Optivem.Kata.Banking.Core.UseCases.OpenAccount;
using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Generators;
using Optivem.Kata.Banking.Infrastructure.Fake.Time;
using Optivem.Kata.Banking.Test.Common.Data;
using Optivem.Kata.Banking.Test.Common.Extensions;
using Optivem.Kata.Banking.Test.Common.Givens;
using Optivem.Kata.Banking.Test.Common.Setup;
using Optivem.Kata.Banking.Test.Common.Utilities;
using Optivem.Kata.Banking.Test.Common.Verification;
using Xunit;
using static Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders.OpenAccountRequestBuilder;

namespace Optivem.Kata.Banking.Test.UseCases
{
    public class OpenAccountUseCaseTest
    {
        private readonly FakeAccountIdGenerator _accountIdGenerator;
        private readonly FakeAccountNumberGenerator _accountNumberGenerator;
        private readonly FakeDateTimeService _dateTimeService;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly OpenAccountUseCase _useCase;

        public OpenAccountUseCaseTest()
        {
            _accountIdGenerator = new FakeAccountIdGenerator();
            _accountNumberGenerator = new FakeAccountNumberGenerator();
            _dateTimeService = new FakeDateTimeService();
            _bankAccountRepository = new FakeBankAccountRepository();
            _useCase = new OpenAccountUseCase(_accountIdGenerator, _accountNumberGenerator, _dateTimeService, _bankAccountRepository);
        }

        [Theory]
        [InlineData("John", "Smith", 0, 325423532, "GB41OMQP68570038161775", "2020-01-12")]
        [InlineData("Mary", "McDonald", 50, 232342, "GB36BMFK75394735916876", "2020-01-12")]
        public async Task Should_open_account_given_valid_request(string firstName, string lastName, int balance,
            long generatedAccountId, string generatedAccountNumber, string openingDateString)
        {
            var openingDate = DateOnlyUtils.From(openingDateString);
            var openingDateTime = openingDate.ToDateTime(TimeOnly.MinValue);

            _accountIdGenerator.WillGenerate(generatedAccountId);
            _accountNumberGenerator.WillGenerate(generatedAccountNumber);
            _dateTimeService.WillReturn(openingDateTime);

            var request = OpenAccount()
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithBalance(balance)
                .Build();

            var expectedResponse = new OpenAccountResponse
            {
                AccountNumber = generatedAccountNumber,
            };

            var response = await _useCase.Handle(request);

            response.Should().BeEquivalentTo(expectedResponse);

            await _bankAccountRepository.ShouldContainAsync(generatedAccountId, generatedAccountNumber, firstName, lastName, openingDate, balance);
        }

        [Theory]
        [ClassData(typeof(NullEmptyWhitespaceStringData))]
        public async Task Should_throw_exception_given_empty_first_name(string firstName)
        {
            var request = OpenAccount().WithFirstName(firstName).Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.FirstNameEmpty);
        }

        [Theory]
        [ClassData(typeof(NullEmptyWhitespaceStringData))]
        public async Task Should_throw_exception_given_empty_last_name(string lastName)
        {
            var request = OpenAccount().WithLastName(lastName).Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.LastNameEmpty);
        }

        [Theory]
        [ClassData(typeof(NegativeIntData))]
        public async Task Should_throw_exception_given_negative_initial_balance(int balance)
        {
            var request = OpenAccount().WithBalance(balance).Build();

            Func<Task> action = () => _useCase.Handle(request);

            await action.Should().ThrowAsync<ValidationException>()
                .WithMessage(ValidationMessages.BalanceNegative);
        }
    }
}