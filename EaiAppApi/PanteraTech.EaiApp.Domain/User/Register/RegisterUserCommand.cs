using MediatR;

namespace PanteraTech.EaiApp.Domain.User.Register
{
    public class RegisterUserCommand : IRequest<long>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}