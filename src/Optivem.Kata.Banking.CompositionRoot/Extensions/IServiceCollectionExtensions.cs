﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Kata.Banking.Core;
using Optivem.Kata.Banking.Core.Domain.BankAccounts;
using Optivem.Kata.Banking.Core.Domain.Time;
using Optivem.Kata.Banking.Infrastructure;
using Optivem.Kata.Banking.Infrastructure.Persistence;

namespace Optivem.Kata.Banking.Web.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {


            // TODO: VC: Move to Startup to enable re-use by tests
            services.AddScoped<IAccountIdGenerator, AccountIdGenerator>();
            services.AddScoped<IAccountNumberGenerator, AccountNumberGenerator>();
            services.AddScoped<IDateTimeService, DateTimeService>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();

            // var connectionString = configuration.GetConnectionString("BankingDatabase");
            var connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING");

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Optivem.Kata.Banking.Infrastructure"));
            });

            services.AddMediatR(typeof(CoreModule));
        }
    }
}