using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PanteraTech.EaiApp.WebApi.Controllers
{
  public class BaseController : ControllerBase
  {

    public string Email
    {
      get
      {
        return User.Claims.FirstOrDefault(c => c.Type.EndsWith("emailaddress"))?.Value;
      }
    }
  }
}