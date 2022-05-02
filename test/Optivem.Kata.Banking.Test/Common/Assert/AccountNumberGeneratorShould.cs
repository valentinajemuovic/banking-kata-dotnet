using FluentAssertions;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Infrastructure.Fake.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Assert
{
    internal static class AccountNumberGeneratorShould
    {
        public static void ShouldGenerateNext(this IAccountNumberGenerator generator, string accountNumber)
        {
            var next = generator.Next();
            next.Should().Be(accountNumber);
        }

        public static void ShouldThrowExceptionOnNext(this IAccountNumberGenerator generator)
        {
            var action = () => generator.Next();

            action.Should().Throw<FakeException>()
                .WithMessage(FakeMessages.GeneratorDoesNotHaveNext);
        }
    }
}
