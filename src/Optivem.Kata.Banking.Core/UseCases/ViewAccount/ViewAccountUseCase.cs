using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases.ViewAccount
{
    public class ViewAccountUseCase : IUseCase<ViewAccountRequest, ViewAccountResponse>
    {
        public Task<ViewAccountResponse> HandleAsync(ViewAccountRequest request)
        {
            var response = new ViewAccountResponse();
            return Task.FromResult(response);
        }
    }
}
