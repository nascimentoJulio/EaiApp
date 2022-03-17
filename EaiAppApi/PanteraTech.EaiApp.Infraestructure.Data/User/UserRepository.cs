using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using PanteraTech.EaiApp.Domain.Repository;
using PanteraTech.EaiApp.Domain.User.GetUsers;
using PanteraTech.EaiApp.Domain.User.Register;
using PanteraTech.EaiApp.Infraestructure.Data.Config;

namespace PanteraTech.EaiApp.Infraestructure.Data.User
{
  public class UserRepository : IUserRepository
  {
    private readonly Configuration _postgresConfiguration;

    public UserRepository()
    {
    }
    public async Task<bool> HasUserWithEmail(string email)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"SELECT * FROM userapp WHERE email = @Email";
        var user = await db.QueryAsync<User>(query, new { Email = email });
        db.Close();

        return user.AsList().Count != 0;
      }
    }

    public async Task<long> InsertUser(RegisterUserCommand user)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"INSERT INTO userapp (email, passwordUser, username, url_profile_user) VALUES(@Email, @Password, @Username, @UrlProfileUser)";
        var id = await db.ExecuteAsync(query, new
        {
          Email = user.Email,
          Password = user.Password,
          Username = user.Username,
          UrlProfileUser = user.UrlProfileUser
        });
        db.Close();

        return id;
      }
    }


    public async Task<RegisterUserCommand> GetUserByEmail(string email)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"Select * from userapp Where email = @Email";
        var user = await db.QueryAsync<User>(query, new { Email = email });
        db.Close();
        if (user.ToList().Count > 0)
        {
          return new RegisterUserCommand
          {
            Email = user.AsList().First().Email,
            Password = user.AsList().First().PasswordUser,
            Username = user.AsList().First().Username,
            UrlProfileUser = user.AsList().First().Url_Profile_User
          };
        }
        return null;
      }
    }

    public async Task<GetUsersCommandResult> GetUsers(string loggedUser)
    {
      using (var db = new NpgsqlConnection("Server=ec2-34-232-149-136.compute-1.amazonaws.com;Port=5432;Database=d8gn66uir43dod;User Id=idgwbyrgklmalo;Password=1084bab71f92c9fae6709d8ad0eb2c7d32f287fa849e2b16392a39e8a7e8f2c8;Ssl Mode=Require;Trust Server Certificate=true;"))
      {
        var query = @"Select * from userapp Where email != @Email";
        var user = await db.QueryAsync<User>(query, new {Email = loggedUser});
        db.Close();
      
        var users = user.Select(u => new UserData 
        {
            UserName = u.Username,
            UrlProfilePhoto = u.Url_Profile_User,
            Email = u.Email
        });
        return new GetUsersCommandResult
        {
         Users = users.ToList()
        };
      }
    }
  }
}