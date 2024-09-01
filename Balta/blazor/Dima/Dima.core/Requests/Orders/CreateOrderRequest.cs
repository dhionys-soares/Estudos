namespace Dima.core.Requests.Orders
{
    public class CreateOrderRequest : Request
    {
        public long ProductId { get; set; }
        public long? VoucherId { get; set; }
    }
}
