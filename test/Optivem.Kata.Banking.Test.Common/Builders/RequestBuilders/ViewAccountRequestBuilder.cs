using Optivem.Kata.Banking.Core.UseCases.ViewAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders
{
    public class ViewAccountRequestBuilder
    {
        private const string DefaultAccountNumber = "GB51BARC20031816295685";

        private string _accountNumber;

        public static ViewAccountRequestBuilder ViewAccount()
        {
            return new ViewAccountRequestBuilder();
        }

        public ViewAccountRequestBuilder()
        {
            _accountNumber = DefaultAccountNumber;
        }

        public ViewAccountRequestBuilder WithAccountNumber(string accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public ViewAccountRequest Build()
        {
            return new ViewAccountRequest
            {
                AccountNumber = _accountNumber,
            };
        }
    }
}
