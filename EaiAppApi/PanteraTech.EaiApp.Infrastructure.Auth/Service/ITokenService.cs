using PanteraTech.EaiApp.Infrastructure.Auth.Model;

namespace PanteraTech.EaiApp.Infrastructure.Auth.Service
{
  public interface ITokenService
  {
    string GenerateToken(string username, string email, string roles);
  }
}