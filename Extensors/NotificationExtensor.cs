using Radzen;

namespace PaxSender.Extensors
{
    public static class NotificationExtensors
    {
        public static void ShowNotification(this NotificationService notifier, 
            string titulo, 
            string mensaje, 
            NotificationSeverity severity)
        {
            var message = new NotificationMessage
            {
                Severity = severity,
                Summary = titulo,
                Detail = mensaje,
                Duration = 3000
            };

            notifier.Notify(message);
        }
    }
}