using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApiTemplate.Repository;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.Notifications;

[ApiController]
[Authorize]
[Route("[controller]")]
public class NotificationController(IUnitOfWork work)
{
    [HttpGet("{guid}")]
    public async Task<IResult> Get(Guid guid)
    {
        var notification = await work.Get<Notification>().GetAsync(guid);
        if (notification is null)
        {
            return new RazorComponentResult(typeof(_404));
        }
        notification.HasSeen = true;
        await work.CompleteAsync();
        return Results.Redirect(notification.RedirectLink ?? "");
    }
}