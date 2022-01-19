using MediatR;

namespace PanteraTech.EaiApp.Domain.User.Login
{
    public class LoginCommand : IRequest<LoginCommandResult>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}