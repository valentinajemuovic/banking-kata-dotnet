using Microsoft.Extensions.Hosting;
using Optivem.Kata.Banking.CompositionRoot.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure.Test.Common
{
    public class HostFixture : IDisposable
    {
        public HostFixture()
        {
            var args = new string[] { };
            HostInstance = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => services.Register(hostContext.Configuration))
                .Build();
        }

        public IHost HostInstance { get; }

        public void Dispose()
        {
            HostInstance.Dispose();
        }
    }
}
