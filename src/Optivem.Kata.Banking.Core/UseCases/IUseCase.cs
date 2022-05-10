namespace Optivem.Kata.Banking.Core.UseCases
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}