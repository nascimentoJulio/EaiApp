using System.Collections.Generic;

namespace PanteraTech.EaiApp.Domain.User.GetUsers
{
    public class GetUsersCommandResult : PagedListModel
    {
        public List<UserData> Users { get; set; }
    }
}