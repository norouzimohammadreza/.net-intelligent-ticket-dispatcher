using IntelligentTicketDispatcher.Contracts;
using IntelligentTicketDispatcher.Dtos.Ticket;
using IntelligentTicketDispatcher.Entities;
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
        await ticketService.CreateTicket(dto, userId);
        return Ok();
    }
}