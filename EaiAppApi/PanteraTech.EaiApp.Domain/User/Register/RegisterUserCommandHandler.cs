using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PanteraTech.EaiApp.Domain.Constanst;
using PanteraTech.EaiApp.Domain.Helpers;
using PanteraTech.EaiApp.Domain.Repository;

namespace PanteraTech.EaiApp.Domain.User.Register
{
  public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, long>
  {
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }
    public async Task<long> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
      if (request.IsValid() != null) throw new HttpException(
         HttpStatusCode.UnprocessableEntity,
          request.IsValid().ErrorCode,
         request.IsValid().ErrorMessage
       );

      var hasUser = await _userRepository.HasUserWithEmail(request.Email);
      if (hasUser)
      {
        throw new HttpException(HttpStatusCode.UnprocessableEntity, Errors.HAS_USER, Errors.HAS_USER_MESSAGE);
      }

      request.Password = CryptographyHelper.Encrypt(request.Password);

      return await _userRepository.InsertUser(request);
    }
  }
}