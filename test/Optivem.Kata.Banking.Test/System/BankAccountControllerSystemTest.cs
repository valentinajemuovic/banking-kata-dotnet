using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Test.System
{
    public class BankAccountControllerSystemTest
    {

        [Fact]
        public async void Nothing()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // TODO: VC: Configure
                });

            var client = application.CreateClient();

            var response = await client.GetAsync("weather");

            response.EnsureSuccessStatusCode();

        }

    }
}
