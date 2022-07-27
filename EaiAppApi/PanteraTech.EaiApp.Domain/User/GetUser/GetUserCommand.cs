using MediatR;

namespace PanteraTech.EaiApp.Domain.User.GetUser
{
  public class GetUserCommand : IRequest<GetUserCommandResult>
  {
    public string EmailLogged { get; set; }
    public string? EmailAnotherUser { get; set; }
  }
}