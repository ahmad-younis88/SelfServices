using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfServices.Common.Entity;
using SelfServices.Common.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServices.API.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationService NotificationService;
        public NotificationController(INotificationService notificationService)
        {
            NotificationService = notificationService;
        }

        [HttpGet]
        [Route("all-notification/{UserNo}")]
        public async Task<List<Notification>> GetNotifications(long UserNo)
        {
            List<Notification> Notifications = await NotificationService.GetNotifications(UserNo);
            return Notifications;
        }

        [HttpGet]
        [Route("notification-by-id/{Id}")]
        public async Task<Notification> GetNotificationById(int Id)
        {
            Notification notification = await NotificationService.GetNotificationById(Id);
            return notification;
        }

        [Authorize]
        [HttpPost]
        [Route("update")]
        public async Task<int> UpdateNotification(Notification notification)
        {
            int nResult = await NotificationService.UpdateNotification(notification);
            return nResult;
        }

        [Authorize]
        [HttpGet]
        [Route("number-of-notification/UserNo/{UserNo}")]
        public async Task<int> GetNumberOfNotification(long UserNo)
        {
            int nNumberOfnotifications = await NotificationService.GetNumberOfNotification(UserNo);
            return nNumberOfnotifications;
        }
    }
}

