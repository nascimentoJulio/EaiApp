namespace PanteraTech.EaiApp.Domain.Chats.GetChats
{
  public class GetChatsCommandResult
  {
    public int Id { get; set; }

    public string UsernameFriend { get; set; }

    public string FriendProfileUrl { get; set;}
    
    public string LastMessage { get; set; }

    public string HourLastMessage { get; set; }

    public string QuantityNoreadMessages { get; set; }
  }
}