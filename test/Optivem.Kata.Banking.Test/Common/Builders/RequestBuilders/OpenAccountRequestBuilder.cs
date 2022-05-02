using Optivem.Kata.Banking.Core.UseCases.OpenAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders
{
    internal class OpenAccountRequestBuilder
    {
        private const string DefaultFirstName = "John";
        private const string DefaultLastName = "Smith";
        private const int DefaultBalance = 10;

        private string _firstName;
        private string _lastName;
        private int _balance;

        public static OpenAccountRequestBuilder AnOpenAccount()
        {
            return new OpenAccountRequestBuilder();
        }

        public OpenAccountRequestBuilder()
        {
            _firstName = DefaultFirstName;
            _lastName = DefaultLastName;
            _balance = DefaultBalance;
        }

        public OpenAccountRequestBuilder FirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public OpenAccountRequestBuilder LastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public OpenAccountRequestBuilder Balance(int balance)
        {
            _balance = balance;
            return this;
        }

        public OpenAccountRequest Build()
        {
            return new OpenAccountRequest
            {
                FirstName = _firstName,
                LastName = _lastName,
                Balance = _balance,
            };
        }


    }
}
