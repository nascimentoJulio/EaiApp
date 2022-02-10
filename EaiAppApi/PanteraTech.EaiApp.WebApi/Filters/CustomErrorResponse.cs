using System.Net;

namespace PanteraTech.EaiApp.WebApi.Filters
{
  public class CustomErrorResponse
  {
    public HttpStatusCode StatusCode { get; set; }

    public string CodeMessage  { get; set; }

    public string Message { get; set; }

  }
}