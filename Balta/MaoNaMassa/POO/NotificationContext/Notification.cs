namespace POO.NotificationContext
{
    public sealed class Notification
    {
        public Notification()
        {
        }

        public Notification(string property, string messege)
        {
            Property = property;
            Messege = messege;
        }

        public string Property { get; set; }
        public string Messege { get; set; }
    }
}