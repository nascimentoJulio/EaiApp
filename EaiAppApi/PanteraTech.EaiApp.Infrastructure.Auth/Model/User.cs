namespace PanteraTech.EaiApp.Infrastructure.Auth.Model
{
    public class User
    {
        public string Email { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string Roles { get; set; }             
    }
}