using Optivem.Kata.Banking.Core.UseCases.OpenAccount;

namespace Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders
{
    public class OpenAccountRequestBuilder
    {
        private const string DefaultFirstName = "John";
        private const string DefaultLastName = "Smith";
        private const int DefaultBalance = 10;

        private string _firstName;
        private string _lastName;
        private int _balance;

        public static OpenAccountRequestBuilder OpenAccount()
        {
            return new OpenAccountRequestBuilder();
        }

        public OpenAccountRequestBuilder()
        {
            _firstName = DefaultFirstName;
            _lastName = DefaultLastName;
            _balance = DefaultBalance;
        }

        public OpenAccountRequestBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public OpenAccountRequestBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public OpenAccountRequestBuilder WithBalance(int balance)
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