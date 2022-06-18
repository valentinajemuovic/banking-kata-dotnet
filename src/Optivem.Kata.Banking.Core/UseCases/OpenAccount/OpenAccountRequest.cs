using MediatR;

namespace Optivem.Kata.Banking.Core.UseCases.OpenAccount
{
    public class OpenAccountRequest : IRequest<OpenAccountResponse>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Balance { get; set; }
    }
}