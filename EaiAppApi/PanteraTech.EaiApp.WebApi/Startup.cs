using System.IO;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PanteraTech.EaiApp.Infrastructure.Auth;
using PanteraTech.EaiApp.Infraestructure.Data.User;
using PanteraTech.EaiApp.Infrastructure.Auth.Service;
using PanteraTech.EaiApp.Domain.Repository;
using PanteraTech.EaiApp.Domain.User.Register;
using PanteraTech.EaiApp.Infraestructure.Data.Config;
using PanteraTech.EaiApp.Infraestructure.Data.Chats;
using PanteraTech.EaiApp.WebApi.Extensions;
using PanteraTech.EaiApp.Infraestructure.Data.Friendship;
using System;

namespace PanteraTech.EaiApp.WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddMediatR(typeof(RegisterUserCommand).Assembly);
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PanteraTech.EaiApp.WebApi", Version = "v1" });
      });
      // var postgreSqlConfiguration = services.GetSection("NpgsqlConnection").Get<Configuration>();

      // services.AddSingleton(postgreSqlConfiguration);


      var key = Encoding.ASCII.GetBytes(Settings.key);

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,

        };
      });

      services.AddScoped<ITokenService, TokenService>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IChatsRepository, ChatsRepository>();
      services.AddScoped<IFriendshipRepository, FriendshipRepository>();
      //   services.AddSingleton(postgreSqlConfiguration);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PanteraTech.EaiApp.WebApi v1"));
      }

      app.UseMyErrorHandler();

      app.UseCors();
      app.UseHttpsRedirection();
     

      app.UseWebSockets();
      app.UseWebSockets();
      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
