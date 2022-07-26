using System;

namespace PanteraTech.EaiApp.Domain.Messages.GetMessageByChat
{
    public class MessagesData
    {
        public int Id { get; set; }

        public string MessageContent { get; set; }

        public DateTime SendDate { get; set; }

        public bool UserSend { get; set; }

    }
}