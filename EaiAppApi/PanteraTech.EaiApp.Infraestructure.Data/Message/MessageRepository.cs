using Dapper;
using Npgsql;
using PanteraTech.EaiApp.Domain.Messages.GetMessageByChat;
using PanteraTech.EaiApp.Domain.Messages.SendMessage;
using PanteraTech.EaiApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Infraestructure.Data.Message
{
    public class MessageRepository : IMessagesRepository
    {
        public async Task<IEnumerable<MessagesData>> GetMessageByChat(GetMessagesByChatCommand command)
        {
            using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
            {

                var query = @"
                               select 
                                     id as Id,
                                     message_content as ""MessageContent"",
                                     date_send as ""DataSend"",
                                     user_send as ""UserSend"",
                                     user_receive as ""UserReceive"" 
                               from messages 
                               where id_chat = @IdChat
                             ";

                var response = await db.QueryAsync<Message>(query, new
                {

                    IdChat = command.IdChat
                });
                db.Close();

                return response.Select(message => new MessagesData
                {
                    Id = message.Id,
                    MessageContent = message.MessageContent,
                    SendDate = message.DataSend,
                    UserSend = message.UserSend == command.EmailUser
                });
            }
        }

        public async Task InsertMessage(SendMessageCommand command)
        {
            using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
            {
             
                var query = @"
                                Insert into messages (message_content, date_send, user_send, user_receive, id_chat)
                                Values(@MessageContent, @DataSend, @UserSend, @UserReceive, @IdChat);
                                
                                Update chats 
                                Set last_message = @MessageContent, hour_last_message = @DataSend, quantity_noread_messages = quantity_noread_messages + 1
                                Where id  = @IdChat 
                             ";

                await db.ExecuteAsync(query, new
                {
                    MessageContent = command.MessageContent,
                    DataSend = command.DataSend,
                    UserSend = command.UserSend,
                    UserReceive = command.UserReceive,
                    IdChat = command.IdChat
                });
                db.Close();

            }
        }

     
    }
}
