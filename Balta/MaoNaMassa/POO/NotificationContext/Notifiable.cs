namespace POO.NotificationContext
{
    public abstract class Notifiable
    {
        protected Notifiable()
        {
            Notifications = new List<Notification>();
        }

        public List<Notification> Notifications { get; set; }
        public bool IsInvalid => Notifications.Any();

        public void AddNotification(Notification notification){
            Notifications.Add(notification);
        }
        public void AddNotifications(IEnumerable<Notification> notification){
            Notifications.AddRange(notification);
        }       
    }
}