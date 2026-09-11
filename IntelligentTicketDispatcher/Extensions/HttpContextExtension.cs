using System.Security.Claims;

namespace IntelligentTicketDispatcher.Extensions;

public static class HttpContextExtension
{
    public static int GetUserId(this HttpContext context)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        return int.TryParse(userId, out var id)
            ? id
            : 0;
    }
}