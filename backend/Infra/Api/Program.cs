using Api;

using Providers.Auth.Microsoft.Behaviors;
using Providers.Auth.Microsoft.Commands;

using Providers.Middlewares.StaticFileAuthentication.Common;
using Providers.Middlewares.StaticFileAuthentication.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.Get<AppSettings>();

builder.Services.AddSingleton(appSettings.Microsoft);

#region SERVICES - MEDIATOR

builder.Services.AddMediatR
(
  typeof(MicrosoftValidateTokenHandler)
);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MicrosoftExceptionBehaviour<,>));

#endregion

#region SERVICES - CONTROLLERS

builder.Services.AddControllers();

#endregion

#region SERVICES - CUSTOM MIDDLEWARES

builder.Services.AddStaticFilesAuthentication
(
  new StaticFilesAuthenticationConfiguration
  {
    Path = "/protected/content",
    AccessTokenIdentifier = "t"
  }
);

#endregion

var app = builder.Build();

#region APP - CORS

app.UseCors
(
  options => options
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins(appSettings.Cors.Origins)
);

#endregion

app.UseHttpsRedirection();

app.UseDefaultFiles();

app.UseAuthentication();

app.UseStaticFilesAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();