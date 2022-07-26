using System;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanteraTech.EaiApp.Domain.Messages.GetMessageByChat;
using PanteraTech.EaiApp.Domain.Messages.SendMessage;
using Serilog;

namespace PanteraTech.EaiApp.WebApi.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessagesController : BaseController
    {

        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{idChat}")]
        [Authorize]
        public async Task<IActionResult> GetMessageByChat(int idChat, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            var command = new GetMessagesByChatCommand
            {
                Page = page,
                PageSize = pageSize,
                IdChat = idChat,
                EmailUser = Email,
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}