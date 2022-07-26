using PanteraTech.EaiApp.Domain.Messages.GetMessageByChat;
using PanteraTech.EaiApp.Domain.Messages.SendMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Repository
{
    public interface IMessagesRepository
    {
        Task<IEnumerable<MessagesData>> GetMessageByChat(GetMessagesByChatCommand command);
        public Task InsertMessage(SendMessageCommand command);
    }
}
