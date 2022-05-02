using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Core.UseCases
{
    public interface IVoidUseCase<in TRequest>
    {
        Task HandleAsync(TRequest request);
    }
}
