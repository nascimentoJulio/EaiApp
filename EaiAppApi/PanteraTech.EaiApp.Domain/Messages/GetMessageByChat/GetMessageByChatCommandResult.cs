using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Messages.GetMessageByChat
{
    public class GetMessageByChatCommandResult : PagedListModel
    {
        public List<MessagesData> Messages { get; set; }
    }
}
