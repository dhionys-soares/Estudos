using POO.SharedContext;

namespace POO.SubscriptionContext
{
    public class Subscription : Base
    {
        public Plan Plan { get; set; }
        public DateTime? EndeDate { get; set; }
        public bool IsInactive => EndeDate <= DateTime.Now;
    }
}