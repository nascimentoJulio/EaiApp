using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PanteraTech.EaiApp.Domain.Repository;

namespace PanteraTech.EaiApp.Domain.Chats.GetChats
{
  public class GetChatsCommandHandler : IRequestHandler<GetChatsCommand, List<GetChatsCommandResult>>
  {
    private readonly IChatsRepository _repository;

    public GetChatsCommandHandler(IChatsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetChatsCommandResult>> Handle(GetChatsCommand request, CancellationToken cancellationToken)
    {
      var result = await _repository.GetChats(request.EmailUser);
      return result;
    }
  }
}