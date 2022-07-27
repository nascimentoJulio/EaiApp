using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Messages.GetMessageByChat
{
    public class GetMessagesByChatCommand : PagedListModel, IRequest<GetMessageByChatCommandResult>
    {
        public int IdChat { get; set; }

        public string EmailUser { get; set; }
    }
}
