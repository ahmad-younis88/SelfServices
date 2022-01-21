using SelfServices.Common.Entity;
using SelfServices.Common.Generic;
using SelfServices.Common.Interface.Repositry;
using SelfServices.Common.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Services.Service
{
    public class NotificationService : IServices, INotificationService
    {
        private readonly INotificationRepositry NotificationRepositry;
        public NotificationService(INotificationRepositry notificationRepositry)
        {
            NotificationRepositry = notificationRepositry;
        }

        public async Task<List<Notification>> GetNotifications(long userNo)
        {
            List<Notification> notifications = await NotificationRepositry.GetNotifications(userNo);
            return notifications;
        }

        public async Task<Notification> GetNotificationById(int Id)
        {
            Notification notifcation = await NotificationRepositry.GetNotificationById(Id);
            return notifcation;
        }

        public async Task<int> UpdateNotification(Notification notification)
        {
            int nResult = await NotificationRepositry.UpdateNotification(notification);
            return nResult;
        }

        public async Task<int> GetNumberOfNotification(long userNo)
        {
            int nNumberOfNotification = await NotificationRepositry.GetNumberOfNotification(userNo);
            return nNumberOfNotification;
        }
    }
}
