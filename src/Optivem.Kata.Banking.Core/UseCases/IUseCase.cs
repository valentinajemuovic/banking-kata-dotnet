using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}
