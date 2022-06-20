using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure.Persistence
{
    internal class BankAccountRecordConfiguration : IEntityTypeConfiguration<BankAccountRecord>
    {
        public void Configure(EntityTypeBuilder<BankAccountRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.AccountNumber)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired();

            builder.Property(e => e.OpeningDate)
                .IsRequired();

            builder.Property(e => e.Balance)
                .IsRequired();
        }
    }
}
