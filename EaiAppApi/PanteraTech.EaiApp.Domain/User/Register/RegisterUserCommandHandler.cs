using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
      var hasUser = await _userRepository.HasUserWithEmail(request.Email);
      if (hasUser)
      {
        throw new Exception("Usuario já cadastrado na base");
      }
      return await _userRepository.InsertUser(request);
    }
  }
}