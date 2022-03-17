

using PanteraTech.EaiApp.Domain.Friendships.GetFriendshipsRequest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Repository
{
    public interface IFriendshipRepository
    {
        Task<List<RequestData>> GetFriendshipRequestAsync(string user_received);

        Task<List<FriendshipData>> GetFriendshipData(string email_friend);

        Task<long> InsertFriendshipRequest(string emailReceived, string userSend);

        Task<bool> ExistsRequestFriendshipWithUsers(string userEmail, string userFriend);

        
    }
}
