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

        private string _firstName;
        private string _lastName;

        public static OpenAccountRequestBuilder AnOpenAccount()
        {
            return new OpenAccountRequestBuilder();
        }

        public OpenAccountRequestBuilder()
        {
            _firstName = DefaultFirstName;
            _lastName = DefaultLastName;
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

        public OpenAccountRequest Build()
        {
            return new OpenAccountRequest
            {
                FirstName = _firstName,
                LastName = _lastName,
            };
        }

    }
}
