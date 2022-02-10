using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PanteraTech.EaiApp.Domain.Constanst;
using PanteraTech.EaiApp.Domain.Helpers;
using PanteraTech.EaiApp.Domain.Repository;
using PanteraTech.EaiApp.Infrastructure.Auth.Service;

namespace PanteraTech.EaiApp.Domain.User.Login
{
  public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
  {
    private readonly IUserRepository _userRepository;

    private readonly ITokenService _tokenService;

    private readonly ILogger _logger;
    public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService, ILoggerFactory logger)
    {
      _userRepository = userRepository;
      _tokenService = tokenService;
      _logger = logger.CreateLogger("Logger");
    }
    public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
      try
      {
        if (request.IsValid() != null) throw new HttpException(
           HttpStatusCode.UnprocessableEntity,
            request.IsValid().ErrorCode,
           request.IsValid().ErrorMessage
         );

        var user = await _userRepository.GetUserByEmail(request.Email);

        user.Password = CryptographyHelper.Decrypt(user.Password);

        if (user == null || !string.Equals(user.Password, request.Password))
        {
          throw new HttpException(HttpStatusCode.UnprocessableEntity, Errors.USER_NOT_FOUND, Errors.USER_NOT_FOUND_MESSAGE);
        }

        var token = _tokenService.GenerateToken(user.Username, user.Email, "user");

        return new LoginCommandResult
        {
          AccessToken = token
        };
      }
      catch (HttpException ex)
      {
        _logger.LogError($@"
            O erro ocorreu na data: {DateTime.Now} 
            usuario: {request.Email}
            Erro:{ex.Message}
            StrackTrace: {ex.StackTrace}");

        throw ex;
      }
    }
  }
}