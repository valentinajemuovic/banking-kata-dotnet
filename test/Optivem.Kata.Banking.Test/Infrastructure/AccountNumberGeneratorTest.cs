using FluentAssertions;
using Optivem.Kata.Banking.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure
{
    public class AccountNumberGeneratorTest
    {
        private readonly AccountNumberGenerator _generator; 

        public AccountNumberGeneratorTest()
        {
            _generator = new AccountNumberGenerator();
        }

        [Fact]
        public void Should_generate_account_number()
        {
            var accountNumber = _generator.Next();
            accountNumber.Should().NotBeNull();
        }

        [Fact]
        public void Should_generate_unique_account_numbers()
        {
            var accountNumber1 = _generator.Next();
            var accountNumber2 = _generator.Next();
            var accountNumber3 = _generator.Next();

            accountNumber2.Should().NotBe(accountNumber1);
            accountNumber3.Should().NotBe(accountNumber2);
        }
    }
}
