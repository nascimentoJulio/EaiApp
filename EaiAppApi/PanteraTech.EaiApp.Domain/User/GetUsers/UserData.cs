

namespace PanteraTech.EaiApp.Domain.User.GetUsers
{
    public class UserData
    {
        public bool IsFriend { get; set; }

        public bool SendRequest { get; set; }

        public bool ReceiveRequest { get; set;}
        
        public string UserName { get; set; }

        public string UrlProfilePhoto { get; set; }

        public string Email { get; set; }
    }
}
