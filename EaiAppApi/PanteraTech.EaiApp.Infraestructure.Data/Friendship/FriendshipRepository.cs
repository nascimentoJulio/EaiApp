using Dapper;
using Npgsql;
using PanteraTech.EaiApp.Domain.Friendships.GetFriendshipsRequest;
using PanteraTech.EaiApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Infraestructure.Data.Friendship
{
  public class FriendshipRepository : IFriendshipRepository
  {
    public async Task<bool> ExistsRequestFriendshipWithUsers(string userEmail, string userFriend)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"select * from requests_friendship  where email_send = @UserEmail and email_receive = @EmailFriend";
        var friendships = await db.QueryAsync<Friendship>(query, new { UserEmail = userEmail, EmailFriend = userFriend });
        db.Close();

        return friendships.Count() > 0;
      }
    }

    public async Task<List<FriendshipData>> GetFriendshipData(string email_friend)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"select * from userapp
                               where  email = @Email";
        var result = await db.QueryAsync<Friend>(query, new { Email = email_friend });
        db.Close();

        var friendships = result.Select(f => new FriendshipData
        {
          Id = f.Id,
          Email = f.Email,
          UrlProfileUser = f.Url_Profile_User,
          Username = f.Username
        });


        return friendships.ToList();
      }
    }

    public async Task<List<RequestData>> GetFriendshipRequestAsync(string user_received)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"select * from requests_friendship
                               where  email_receive = @Email";
        var result = await db.QueryAsync<Friendship>(query, new { Email = user_received });
        db.Close();

        var friendships = result.Select(f => new RequestData
        {
          Email = f.Email_Send
        });


        return friendships.ToList();
      }
    }

    public async Task<long> InsertFriendshipRequest(string emailReceived, string userSend)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"insert into requests_friendship(email_send, email_receive)
                              values(@EmailSend, @EmailReceive)";

        var result = await db.ExecuteAsync(query, new { EmailSend = userSend, EmailReceive = emailReceived });
        db.Close();

        return result;
      }
    }


  }
}
