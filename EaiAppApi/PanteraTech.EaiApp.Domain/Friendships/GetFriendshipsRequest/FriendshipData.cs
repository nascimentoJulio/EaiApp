using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Friendships.GetFriendshipsRequest
{
    public class FriendshipData
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string Email{ get; set; }

        public string UrlProfileUser { get; set; }
    }
}
