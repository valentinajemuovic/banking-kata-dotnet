using Optivem.Kata.Banking.Core.UseCases.WithdrawFunds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders
{
    internal class WithdrawFundsRequestBuilder
    {
        private const string DefaultAccountNumber = "GB51BARC20031816295685";


        public static WithdrawFundsRequestBuilder WithdrawFundsRequest()
        {
            return new WithdrawFundsRequestBuilder();
        }

        private string _accountNumber;

        public WithdrawFundsRequestBuilder()
        {
            AccountNumber(DefaultAccountNumber);
        }

        public WithdrawFundsRequestBuilder AccountNumber(string accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public WithdrawFundsRequest Build()
        {
            return new WithdrawFundsRequest
            {
                AccountNumber = _accountNumber,
            };
        }

    }
}
