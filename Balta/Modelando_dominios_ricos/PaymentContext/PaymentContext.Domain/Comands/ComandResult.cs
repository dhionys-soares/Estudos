using PaymentContext.Shared.Comands;

namespace PaymentContext.Domain.Comands
{
    public class ComandResult : IComandResult
    {
        public ComandResult()
        {
        }

        public ComandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}