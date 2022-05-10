namespace Optivem.Kata.Banking.Core.UseCases
{
    public interface IVoidUseCase<in TRequest>
    {
        Task HandleAsync(TRequest request);
    }
}