using IntelligentTicketDispatcher.Contracts;
using IntelligentTicketDispatcher.Dtos.Ticket;
using IntelligentTicketDispatcher.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentTicketDispatcher.Controllers;

[ApiController]
[Produces("application/json")]
public class TicketsController(ITicketService ticketService) : Controller
{
    public async Task<IActionResult> Create([FromBody] CreateTicketDto dto)
    {
        var userId = Request.HttpContext.GetUserId();
        var result = await ticketService.CreateTicket(dto, userId);
        return Ok(result);
    }

    public async Task<IActionResult> Answer([FromBody] string answer, int ticketId)
    {
        var userId = Request.HttpContext.GetUserId();
        var result = await ticketService.Answer(answer, userId, ticketId);
        return Ok(result);
    }
}