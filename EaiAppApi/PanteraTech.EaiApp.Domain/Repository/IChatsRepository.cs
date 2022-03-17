using System.Collections.Generic;
using System.Threading.Tasks;
using PanteraTech.EaiApp.Domain.Chats.CreateChats;
using PanteraTech.EaiApp.Domain.Chats.GetChats;

namespace PanteraTech.EaiApp.Domain.Repository
{
    public interface IChatsRepository
    {
         Task<long> CreateChat(CreateChatsCommand values);

         Task<List<GetChatsCommandResult>> GetChats(string userEmail);

        Task<bool> ExistsChatWithUsers(string userEmail, string userFriend);
    }
}