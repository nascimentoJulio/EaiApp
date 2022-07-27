

using MediatR;

namespace PanteraTech.EaiApp.Domain.User.GetUsers
{
  public class GetUsersCommand : PagedListModel, IRequest<GetUsersCommandResult>
  {
    public string Email { get; set; }
  }
}
