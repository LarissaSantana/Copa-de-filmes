using CopaDeFilmes.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CopaDeFilmes.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly INotificationContext<Notification> _notification;

        public BaseController(INotificationContext<Notification> notification)
        {
            _notification = notification;
        }

        protected List<string> GetErrorListFromModelState()
        {
            var errors = new List<string>();
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                errors.Add(errorMsg);
            }
            return errors;
        }

        protected IActionResult GetResponse()
        {
            return GetResponse(null);
        }

        protected IActionResult GetResponse(object result)
        {
            if (_notification != null && _notification.HasNotifications())
            {
                return BadRequest(_notification.GetNotifications().Select(n => n.Value));
            }

            if (result == null) return Ok();

            return Ok(result);
        }
    }
}
