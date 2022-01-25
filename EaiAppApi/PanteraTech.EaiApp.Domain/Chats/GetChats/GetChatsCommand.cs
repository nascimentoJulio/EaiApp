using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace PanteraTech.EaiApp.Domain.Chats.GetChats
{
    public class GetChatsCommand : IRequest<List<GetChatsCommandResult>>
    {
        [JsonIgnore]
        public string EmailUser { get; set; }
    }
}