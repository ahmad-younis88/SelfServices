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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNotifications(long UserNo)
        {
            try
            {
                List<Notification> Notifications = await NotificationService.GetNotifications(UserNo);
                return Ok(new { isSuccess = true, Message = "", data = Notifications });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet]
        [Route("notification-by-id/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNotificationById(int Id)
        {
            try
            {
                Notification notification = await NotificationService.GetNotificationById(Id);
                return Ok(new { isSuccess = true, Message = "", data = notification });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateNotification(Notification notification)
        {
            try
            {
                int nResult = await NotificationService.UpdateNotification(notification);
                return Ok(new { isSuccess = nResult > 0 ? true : false, Message = "", data = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("number-of-notification/UserNo/{UserNo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNumberOfNotification(long UserNo)
        {
            try
            {
                int nNumberOfnotifications = await NotificationService.GetNumberOfNotification(UserNo);
                return Ok(new { isSuccess = true , Message = "", data = nNumberOfnotifications });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

