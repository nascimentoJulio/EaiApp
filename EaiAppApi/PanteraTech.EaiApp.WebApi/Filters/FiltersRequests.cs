using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PanteraTech.EaiApp.Domain;

namespace PanteraTech.EaiApp.WebApi.Filters
{
  public class FiltersRequests
  {
    private readonly RequestDelegate _next;
    private readonly ILogger _log;

    public FiltersRequests(RequestDelegate next, ILoggerFactory log)
    {
      this._next = next;
      this._log = log.CreateLogger("MyErrorHandler");
    }

    public async Task Invoke(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (HttpException ex)
      {
        await HandleErrorAsync(httpContext, ex);
      }
    }

    private async Task HandleErrorAsync(HttpContext context, HttpException exception)
    {
      var errorResponse = new CustomErrorResponse
      {
        StatusCode = exception.StatusCode,
        CodeMessage = exception.CodeMessage,
        Message = exception.Message
      };


      _log.LogError($"Error: {exception.StackTrace}");

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)errorResponse.StatusCode;
      await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
    }
  }
}
