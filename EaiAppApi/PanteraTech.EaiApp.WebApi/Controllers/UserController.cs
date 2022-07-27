using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanteraTech.EaiApp.Domain.User.GetUser;
using PanteraTech.EaiApp.Domain.User.GetUsers;
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
      return Ok(new { IsValid = ExpireDateToken.Date.CompareTo(DateTime.Now) >= 0 });
    }

    [HttpGet("/users")]
    [Authorize]
    public async Task<IActionResult> GetUsers([FromQuery] int page, [FromQuery] int pageSize)
    {
      const int FIRST_PAGE = 1;
      const int DEFAULT_PAGE_SIZE = 10;
      var command = new GetUsersCommand
      {
        PageSize = pageSize != null && pageSize > 0 ? pageSize : DEFAULT_PAGE_SIZE,
        Page = page != null && page > 0 ? page : FIRST_PAGE,
        Email = Email
      };

      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpGet("/{email}")]
    [Authorize]
    public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
    {
      var command = new GetUserCommand
      {
        EmailLogged = Email,
        EmailAnotherUser = email
      };

      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpGet("/me")]
    [Authorize]
    public async Task<IActionResult> GetLoggedUser()
    {
      var command = new GetUserCommand
      {
        EmailLogged = Email,
        EmailAnotherUser = Email
      };

      var result = await _mediator.Send(command);

      return Ok(result);
    }
  }
}