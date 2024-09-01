namespace Dima.core.Requests.Orders
{
    public class GetOrderByNumberRequest : Request
    {
        public string Number { get; set; } = string.Empty;
    }
}
