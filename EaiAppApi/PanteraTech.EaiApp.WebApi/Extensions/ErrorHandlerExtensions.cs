using Microsoft.AspNetCore.Builder;
using PanteraTech.EaiApp.WebApi.Filters;

namespace PanteraTech.EaiApp.WebApi.Extensions
{
  public static class ErrorHandlerExtensions
  {
    public static IApplicationBuilder UseMyErrorHandler(this IApplicationBuilder appBuilder)
    {
      return appBuilder.UseMiddleware<FiltersRequests>();
    }
  }
}