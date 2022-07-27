using MediatR;
using Microsoft.AspNetCore.SignalR;
using PanteraTech.EaiApp.Domain.Messages.SendMessage;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.WebApi.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public string GetConnectionId() => Context.ConnectionId;

        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendMessages(string loggedUser, string message, string userReceive, int idChat)
        {
            var command = new SendMessageCommand
            {
                MessageContent = message,
                UserSend = loggedUser,
                UserReceive = userReceive,
                IdChat = idChat
            };

            await _mediator.Send(command);

            await Clients.All.SendAsync("ReceiveMessage", loggedUser, message, userReceive);
        }
    }
}