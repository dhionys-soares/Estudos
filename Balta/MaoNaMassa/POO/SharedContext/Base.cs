using POO.NotificationContext;

namespace POO.SharedContext
{
    public abstract class Base : Notifiable
    {
        protected Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}