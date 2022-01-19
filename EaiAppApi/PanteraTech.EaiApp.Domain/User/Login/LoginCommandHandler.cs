using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PanteraTech.EaiApp.Domain.Repository;
using PanteraTech.EaiApp.Infrastructure.Auth.Service;

namespace PanteraTech.EaiApp.Domain.User.Login
{
  public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
  {
    private readonly IUserRepository _userRepository;

    private readonly ITokenService _tokenService;
    public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService)
    {
      _userRepository = userRepository;
      _tokenService = tokenService;
    }
    public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
      var user = await _userRepository.GetUserByEmail(request.Email);
      if (user == null || !string.Equals(user.Password, request.Password))
      {
        throw new Exception("Usuario não cadastrado");
      }

      var token = _tokenService.GenerateToken(user.Username,user.Email, "user");

      return new LoginCommandResult
      {
        AccessToken = token  
      };
    }
  }
}