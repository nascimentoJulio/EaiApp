using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using System;

namespace PanteraTech.EaiApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void AcceptWebSocketAsyncBackgroundSocketProcessor(WebApplication app)
        {
            // <snippet_AcceptWebSocketAsyncBackgroundSocketProcessor>
            app.Run(async (context) =>
            {
                using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                var socketFinishedTcs = new TaskCompletionSource<object>();

                BackgroundSocketProcessor.AddSocket(webSocket, socketFinishedTcs);

                await socketFinishedTcs.Task;
            });
            // </snippet_AcceptWebSocketAsyncBackgroundSocketProcessor>
        }

        public static void UseWebSocketsOptionsAllowedOrigins(WebApplication app)
        {
            // <snippet_UseWebSocketsOptionsAllowedOrigins>
            var webSocketOptions = new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromMinutes(2)
            };

            webSocketOptions.AllowedOrigins.Add("https://client.com");
            webSocketOptions.AllowedOrigins.Add("https://www.client.com");

            app.UseWebSockets(webSocketOptions);
            // </snippet_UseWebSocketsOptionsAllowedOrigins>
        }
    }
}



