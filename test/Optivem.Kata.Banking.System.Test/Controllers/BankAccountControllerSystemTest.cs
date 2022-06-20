using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Optivem.Kata.Banking.System.Test.Controllers.Common;
using Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.System.Test.Controllers
{
    public class BankAccountControllerSystemTest : BaseTest
    {
        public BankAccountControllerSystemTest(HostFixture fixture) : base(fixture)
        {

        }

        [Fact]
        public async Task Nothing()
        {
            var response = await Client.GetAsync("weather");

            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async Task Should_open_bank_account_given_valid_request()
        {
            var url = "bank-accounts";

            var request = OpenAccountRequestBuilder.OpenAccount()
                .Build();

            var json = JsonConvert.SerializeObject(request);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(url, body);

            response.EnsureSuccessStatusCode();
        }

    }
}
