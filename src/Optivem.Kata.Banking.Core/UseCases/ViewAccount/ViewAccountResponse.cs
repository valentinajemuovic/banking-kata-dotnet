using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.ViewAccount
{
    public class ViewAccountResponse
    {
        public string? AccountNumber { get; set; }
        public string? FullName { get; set; }
        public int Balance { get; set; }
    }
}
