using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Kata.Banking.Test.Common.Extensions
{
    public static class IRequestHandlerExtensions
    {
        public static Task<TResponse> Handle<TRequest, TResponse>(this IRequestHandler<TRequest, TResponse> handler, TRequest request)
            where TRequest : IRequest<TResponse>
        {
            return handler.Handle(request, CancellationToken.None);
        }
    }
}
