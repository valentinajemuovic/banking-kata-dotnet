﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Kata.Banking.Infrastructure.Test.Common
{
    public class BaseTest : IClassFixture<HostFixture>
    {
        private readonly HostFixture _fixture;

        public BaseTest(HostFixture fixture)
        {
            _fixture = fixture;
        }

        public T GetService<T>() where T : notnull
        {
            return _fixture.HostInstance.Services.GetRequiredService<T>();
        }
    }
}
