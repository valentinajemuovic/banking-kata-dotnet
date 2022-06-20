using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.System.Test.Controllers.Common
{
    public class BaseTest : IClassFixture<HostFixture>
    {
        private readonly HostFixture _fixture;

        public BaseTest(HostFixture fixture)
        {
            _fixture = fixture;
        }

        public HttpClient Client => _fixture.Client;
    }
}
