using System;
using System.Net;
using System.Text.Json.Serialization;

namespace PanteraTech.EaiApp.Domain
{
  public class HttpException : Exception
  {
    public HttpStatusCode StatusCode { get; private set; }

    public string? Message { get; set; }

    public string? CodeMessage { get; set; }

    public HttpException(HttpStatusCode statusCode, string codeMessage, string message)
    {
      this.StatusCode = statusCode;
      this.CodeMessage = codeMessage;
      this.Message = message;
    }

     public HttpException(HttpStatusCode statusCode)
    {
      this.StatusCode = statusCode;
    }
  }
}
