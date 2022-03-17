using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanteraTech.EaiApp.Domain.Friendships.GetFriendshipsRequest;
using PanteraTech.EaiApp.Domain.Friendships.InsertFriendship;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.WebApi.Controllers
{
    [ApiController]
    [Route("/friendships")]
    public class FriendsController : BaseController
    {
        private readonly IMediator _mediator;
        public FriendsController(IMediator mediator)
        {
            this._mediator = mediator;   
        }

        [HttpGet("/requests")]
        [Authorize]
        public async Task<IActionResult> GetRequestsFriendship([FromQuery] GetRequestFriendshipsCommand friendshipsParams)
        {
            const int FIRST_PAGE = 1;
            const int DEFAULT_PAGE_SIZE = 10;
            var command = new GetRequestFriendshipsCommand
            {
                PageSize = friendshipsParams.PageSize != null && friendshipsParams.PageSize > 0 ? friendshipsParams.PageSize : DEFAULT_PAGE_SIZE,
                Page = friendshipsParams.Page!= null && friendshipsParams.Page > 0 ? friendshipsParams.Page: FIRST_PAGE,
                EmailUser = Email
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("/requests/{emailReceive}")]
        [Authorize]
        public async Task<IActionResult> GetRequestsFriendship(string emailReceive)
        {
            var command = new InsertFriendshipCommand
            {
                EmailReceive = emailReceive,
                EmailSend = Email
            };
            var result = await _mediator.Send(command);
            return Created("/requests/{emailReceive}", result);
        }
    }
}
