namespace PanteraTech.EaiApp.Domain.User.GetUser
{
  public class GetUserCommandResult
  {
    public bool ItsMe { get; set; }
    public bool IsFriend { get; set; }

    public bool SendRequest { get; set; }

    public bool ReceiveRequest { get; set; }

    public string Username { get; set; }

    public string UrlProfilePhoto { get; set; }

    public string Email { get; set; }
  }
}