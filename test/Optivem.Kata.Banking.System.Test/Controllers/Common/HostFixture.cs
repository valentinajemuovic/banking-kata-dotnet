using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.System.Test.Controllers.Common
{
    public class HostFixture : IDisposable
    {
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public HostFixture()
        {
            _webApplicationFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // var configuration = builder.Ser

                    // builder.ConfigureServices(services => services.Register(builder.Conf))
                    // TODO: VC: Configure
                });

            Client = _webApplicationFactory.CreateClient();
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _webApplicationFactory.Dispose();
        }
    }
}
