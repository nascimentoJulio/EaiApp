using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PanteraTech.EaiApp.Domain.Repository;

namespace PanteraTech.EaiApp.Domain.User.GetUser
{
  public class GetUserCommandHandler : IRequestHandler<GetUserCommand, GetUserCommandResult>
  {
    private readonly IUserRepository _userRepository;

    private readonly IChatsRepository _chatsRepository;

    private readonly IFriendshipRepository _friendshipRepository;

    public GetUserCommandHandler(IUserRepository userRepository, IFriendshipRepository friendshipRepository, IChatsRepository chatsRepository)
    {
      _userRepository = userRepository;
      _friendshipRepository = friendshipRepository;
      _chatsRepository = chatsRepository;
    }
    public async Task<GetUserCommandResult> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
      var user = await _userRepository.GetUserByEmail(request.EmailAnotherUser ?? request.EmailLogged);

      if (user == null) throw new HttpException(HttpStatusCode.NotFound);

      GetUserCommandResult result = new GetUserCommandResult();

      if (request.EmailLogged.Equals(request.EmailAnotherUser))
      {
        result.ItsMe = true;
        result.IsFriend = false;
        result.ReceiveRequest = false;
        result.SendRequest = false;
        result.Email = request.EmailLogged;
        result.UrlProfilePhoto = user.UrlProfileUser;
        result.Username = user.Username;
        return result;
      }

      result.ItsMe = false;
      result.IsFriend = await _chatsRepository.ExistsChatWithUsers(request.EmailLogged, request.EmailAnotherUser);
      result.ReceiveRequest = await _friendshipRepository.ExistsRequestFriendshipWithUsers(request.EmailAnotherUser, request.EmailLogged);
      result.SendRequest = await _friendshipRepository.ExistsRequestFriendshipWithUsers(request.EmailLogged, request.EmailAnotherUser);
      result.Email = request.EmailLogged;
      result.UrlProfilePhoto = user.UrlProfileUser;
      result.Username = user.Username;

      return result;

    }
  }
}