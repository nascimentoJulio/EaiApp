using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PanteraTech.EaiApp.WebApi.Controllers
{
  [ApiController]
  [Route("messages")]
  public class MessagesController : BaseController
  {

    [HttpGet("teste")]
    public async Task Test()
    {
      if (HttpContext.WebSockets.IsWebSocketRequest)
      {
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
        await Echo(webSocket);
      }
      else
      {
        HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
      }
    }

    private static async Task Echo(WebSocket webSocket)
{
    var buffer = new byte[1024 * 4];
    var receiveResult = await webSocket.ReceiveAsync(
        new ArraySegment<byte>(buffer), CancellationToken.None);

    while (!receiveResult.CloseStatus.HasValue)
    {
        await webSocket.SendAsync(
            new ArraySegment<byte>(buffer, 0, receiveResult.Count),
            receiveResult.MessageType,
            receiveResult.EndOfMessage,
            CancellationToken.None);

        receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);
    }

    await webSocket.CloseAsync(
        receiveResult.CloseStatus.Value,
        receiveResult.CloseStatusDescription,
        CancellationToken.None);
}
  }
}