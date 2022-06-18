using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Optivem.Kata.Banking.Test.Common.Builders.RequestBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.System
{
    public class BankAccountControllerSystemTest : IDisposable
    {
        private readonly HttpClient _client;

        public BankAccountControllerSystemTest()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // TODO: VC: Configure
                });

            _client = application.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
        }


        [Fact]
        public async Task Nothing()
        {
            var response = await _client.GetAsync("weather");

            response.EnsureSuccessStatusCode();

        }

        [Fact(Skip = "TODO: In progress")]
        public async Task Should_open_bank_account_given_valid_request()
        {
            var url = "bank-accounts";

            var request = OpenAccountRequestBuilder.OpenAccount()
                .Build();

            var json = JsonConvert.SerializeObject(request);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, body);

            response.EnsureSuccessStatusCode();
        }

    }
}
