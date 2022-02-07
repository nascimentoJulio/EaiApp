using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using PanteraTech.EaiApp.Domain.Chats.CreateChats;
using MediatR;
using PanteraTech.EaiApp.Domain.Chats.GetChats;

namespace PanteraTech.EaiApp.WebApi.Controllers
{
    [ApiController]
    [Route("/chats")]
    public class Chats : ControllerBase
    {
        private readonly IMediator _mediator;
        public Chats(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateChats(CreateChatsCommand command)
        {
            var email =  User.Claims.FirstOrDefault(c => c.Type.EndsWith("emailaddress"))?.Value;
            command.UserEmail = email;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var email =  User.Claims.FirstOrDefault(c => c.Type.EndsWith("emailaddress"))?.Value;
            GetChatsCommand command = new GetChatsCommand{ EmailUser = email};
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        
        
    }
}