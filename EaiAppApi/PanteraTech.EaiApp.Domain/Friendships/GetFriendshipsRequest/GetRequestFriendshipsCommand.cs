using MediatR;
using Newtonsoft.Json;
using PagedList;
using System.Collections.Generic;

namespace PanteraTech.EaiApp.Domain.Friendships.GetFriendshipsRequest
{
    public class GetRequestFriendshipsCommand : PagedListModel, IRequest<GetRequestFrindshipsCommandResult>
    {
        
        [JsonIgnore]
        public string EmailUser { get; set; }
    }
}
