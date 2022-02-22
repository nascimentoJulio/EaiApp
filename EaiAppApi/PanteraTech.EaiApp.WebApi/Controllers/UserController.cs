using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanteraTech.EaiApp.Domain.User.Login;
using PanteraTech.EaiApp.Domain.User.Register;
using PanteraTech.EaiApp.Infrastructure.Auth;
using PanteraTech.EaiApp.Infrastructure.Auth.Service;

namespace PanteraTech.EaiApp.WebApi.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }

        [HttpGet("/validate-token")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            return Ok(new {IsValid = ExpireDateToken.Date.CompareTo(DateTime.Now) >= 0});
        }
    }
}