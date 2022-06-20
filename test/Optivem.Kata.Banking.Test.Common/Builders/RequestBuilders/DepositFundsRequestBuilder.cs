using Optivem.Kata.Banking.Core.UseCases.DepositFunds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders
{
    public class DepositFundsRequestBuilder
    {
        private const string DefaultAccountNumber = "GB51BARC20031816295685";
        private const int DefaultAmount = 300;

        public static DepositFundsRequestBuilder DepositFundsRequest()
        {
            return new DepositFundsRequestBuilder();
        }

        private string _accountNumber;
        private int _amount;

        public DepositFundsRequestBuilder()
        {
            _accountNumber = DefaultAccountNumber;
            _amount = DefaultAmount;
        }

        public DepositFundsRequestBuilder WithAccountNumber(string accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public DepositFundsRequestBuilder WithAmount(int amount)
        {
            _amount = amount;
            return this;
        }

        public DepositFundsRequest Build()
        {
            return new DepositFundsRequest
            {
                AccountNumber = _accountNumber,
                Amount = _amount,
            };
        }
    }
}
