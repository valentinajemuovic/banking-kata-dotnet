using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Infrastructure.Persistence
{
    public class BankAccountRecord
    {
        public long Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime OpeningDate { get; set; }
        public int Balance { get; set; }

    }
}
