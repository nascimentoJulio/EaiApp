
using System.Collections.Generic;

namespace PanteraTech.EaiApp.Domain.Friendships.GetFriendshipsRequest
{
    public class GetRequestFrindshipsCommandResult : PagedListModel
    {
        public List<FriendshipData> UserData { get; set; }
    }
}
