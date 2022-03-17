using System.Threading.Tasks;
using PanteraTech.EaiApp.Domain.User.GetUsers;
using PanteraTech.EaiApp.Domain.User.Register;

namespace PanteraTech.EaiApp.Domain.Repository
{
    public interface IUserRepository
    {
         Task<bool> HasUserWithEmail(string email);
         
         Task<long> InsertUser(RegisterUserCommand user);

         Task<RegisterUserCommand> GetUserByEmail(string email);

        Task<GetUsersCommandResult> GetUsers(string loggedUser);

    }
}