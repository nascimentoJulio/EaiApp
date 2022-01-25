using System.Text.Json.Serialization;
using MediatR;

namespace PanteraTech.EaiApp.Domain.Chats.CreateChats
{
  public class CreateChatsCommand : IRequest<long>
  {
    [JsonIgnore]
    public string UserEmail { get; set; }

    public string EmailFriend { get; init; }
  }
}