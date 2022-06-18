using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.ViewAccount
{
    public class ViewAccountRequest : IRequest<ViewAccountResponse>
    {
        public string? AccountNumber { get; set; }
    }
}
