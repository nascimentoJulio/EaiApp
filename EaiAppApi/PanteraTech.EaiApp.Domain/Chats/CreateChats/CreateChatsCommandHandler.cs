using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
      var id = await _repository.CreateChat(request);
      return id;
    }
  }
}