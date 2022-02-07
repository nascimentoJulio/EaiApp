using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Npgsql;
using PanteraTech.EaiApp.Domain.Chats.CreateChats;
using PanteraTech.EaiApp.Domain.Chats.GetChats;
using PanteraTech.EaiApp.Domain.Repository;

namespace PanteraTech.EaiApp.Infraestructure.Data.Chats
{
  public class ChatsRepository : IChatsRepository
  {
    public async Task<long> CreateChat(CreateChatsCommand values)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"insert into chats (email_user, email_friend) Values(@EmailUser, @EmailFriend) RETURNING id";
        var id = await db.ExecuteAsync(query, new { EmailUser = values.UserEmail, EmailFriend = values.EmailFriend });
        db.Close();

        return id;
      }
    }

    public async Task<List<GetChatsCommandResult>> GetChats(string userEmail)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query =
        @"select * from chats c 
        inner join userapp u on c.email_friend = u.email
        where c.email_user = @Email";
        var chats = await db.QueryAsync<Chats>(query, new { Email = userEmail });
        db.Close();
        var response = new List<GetChatsCommandResult>();
        chats.ToList().ForEach(c => response.Add(new GetChatsCommandResult
        {
          Id = c.Id,
          UsernameFriend = c.Username,
          FriendProfileUrl = c.Url_Profile_User,
          HourLastMessage = c.Hour_Last_Message,
          LastMessage = c.Last_Message,
          QuantityNoreadMessages = c.Quantity_Noread_Messages
        }));

        return response;
      }
    }
  }
}