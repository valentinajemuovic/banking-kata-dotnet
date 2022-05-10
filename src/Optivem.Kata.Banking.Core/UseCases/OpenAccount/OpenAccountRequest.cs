namespace Optivem.Kata.Banking.Core.UseCases.OpenAccount
{
    public class OpenAccountRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Balance { get; set; }
    }
}