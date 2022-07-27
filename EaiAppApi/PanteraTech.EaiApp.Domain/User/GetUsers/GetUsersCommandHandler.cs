using MediatR;
using PagedList;
using PanteraTech.EaiApp.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.User.GetUsers
{
  public class GetUsersCommandHandler : IRequestHandler<GetUsersCommand, GetUsersCommandResult>
  {
    private readonly IUserRepository _userRepository;

    private readonly IChatsRepository _chatsRepository;

    private readonly IFriendshipRepository _friendshipRepository;

    public GetUsersCommandHandler(IUserRepository userRepository, IFriendshipRepository friendshipRepository, IChatsRepository chatsRepository)
    {
      _userRepository = userRepository;
      _friendshipRepository = friendshipRepository;
      _chatsRepository = chatsRepository;
    }

    public async Task<GetUsersCommandResult> Handle(GetUsersCommand request, CancellationToken cancellationToken)
    {
      var users = await _userRepository.GetUsers(request.Email);
      var pagedList = users.Users.ToPagedList(request.Page, request.PageSize);



      var result = new GetUsersCommandResult
      {
        HasNextPage = pagedList.HasNextPage,
        IsFirstPage = pagedList.IsFirstPage,
        IsLastPage = pagedList.IsLastPage,
        HasPreviousPage = pagedList.HasPreviousPage,
        PageNumber = pagedList.PageNumber,
        Users = users.Users
      };

      List<UserData> newUsers = new List<UserData>();

      foreach (var u in users.Users)
      {
        var isFriend = await _chatsRepository.ExistsChatWithUsers(request.Email, u.Email) || await _chatsRepository.ExistsChatWithUsers(u.Email, request.Email);
        var receiveRequest = await _friendshipRepository.ExistsRequestFriendshipWithUsers(request.Email, u.Email);
        var sendRequest = await _friendshipRepository.ExistsRequestFriendshipWithUsers(u.Email, request.Email);
        var user = new UserData
        {
          IsFriend = isFriend,
          ReceiveRequest = receiveRequest,
          SendRequest = sendRequest,
          UserName = u.UserName,
          UrlProfilePhoto = u.UrlProfilePhoto,
          Email = u.Email
        };

        newUsers.Add(user);
      }

      return new GetUsersCommandResult
      {
        HasNextPage = pagedList.HasNextPage,
        IsFirstPage = pagedList.IsFirstPage,
        IsLastPage = pagedList.IsLastPage,
        HasPreviousPage = pagedList.HasPreviousPage,
        PageNumber = pagedList.PageNumber,
        Users = newUsers
      };
    }
  }
}
