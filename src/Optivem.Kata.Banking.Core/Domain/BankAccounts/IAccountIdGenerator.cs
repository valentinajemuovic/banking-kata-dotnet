using Optivem.Kata.Banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.Domain.BankAccounts
{
    public interface IAccountIdGenerator : IGenerator<AccountId>
    {
    }
}
