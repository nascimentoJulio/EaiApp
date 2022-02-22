using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PanteraTech.EaiApp.WebApi.Controllers
{
  public class BaseController : ControllerBase
  {

    public DateTime ExpireDateToken
    {
      get
      {
       var expireDate = User.Claims.FirstOrDefault(c => c.Type.EndsWith("ExpireDate"))?.Value;
       return DateTime.Parse(expireDate);
      }
    }
    
    public string Email
    {
      get
      {
        return User.Claims.FirstOrDefault(c => c.Type.EndsWith("emailaddress"))?.Value;

      }
    }
  }
}