using SelfServices.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Common.Interface.Repositry
{
    public interface INotificationRepositry
    {
        Task<List<Notification>> GetNotifications(long userNo);
        Task<Notification> GetNotificationById(int Id);
        Task<int> UpdateNotification(Notification notification);
        Task<int> GetNumberOfNotification(long userNo);
    }
}
