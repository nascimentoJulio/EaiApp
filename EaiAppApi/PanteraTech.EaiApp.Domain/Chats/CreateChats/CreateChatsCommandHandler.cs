using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PanteraTech.EaiApp.Domain.Constanst;
using PanteraTech.EaiApp.Domain.Repository;

namespace PanteraTech.EaiApp.Domain.Chats.CreateChats
{
  public class CreateChatsCommandHandler : IRequestHandler<CreateChatsCommand, long>
  {
    private readonly IChatsRepository _repository;

    public CreateChatsCommandHandler(IChatsRepository repository)
    {
      _repository = repository;
    }

    public async Task<long> Handle(CreateChatsCommand request, CancellationToken cancellationToken)
    {
      if (request.IsValid() != null) throw new HttpException(
          HttpStatusCode.UnprocessableEntity,
           request.IsValid().ErrorCode,
          request.IsValid().ErrorMessage
        );

      if (request.EmailFriend.Equals(request.UserEmail))
      {
        throw new HttpException(HttpStatusCode.UnprocessableEntity, Errors.SAME_USER, Errors.SAME_USER_MESSAGE);
      }
      
      var id = await _repository.CreateChat(request);
      return id;
    }
  }
}