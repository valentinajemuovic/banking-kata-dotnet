using Optivem.Kata.Banking.Infrastructure.Fake.BankAccounts;
using Optivem.Kata.Banking.Test.Common.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.Infrastructure.Fake
{
    public class FakeBankAccountRepositoryTest
    {
        private readonly FakeBankAccountRepository _repository;

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


        /*
         * 
    @Test
    void  {
        var accountNumber = "GB36BARC20038032622823";

        verifyThat(repository).doesNotContain(accountNumber);
    }
         * 
         * 
         */

    }
}
