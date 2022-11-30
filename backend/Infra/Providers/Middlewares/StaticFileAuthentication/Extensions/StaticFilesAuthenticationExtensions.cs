using Providers.Middlewares.StaticFileAuthentication.Common;

namespace Providers.Middlewares.StaticFileAuthentication.Extensions;

public static class StaticFilesAuthenticationExtensions
{
  public static IServiceCollection AddStaticFilesAuthentication(this IServiceCollection services, StaticFilesAuthenticationConfiguration configuration)
  {
    services.AddScoped(provider =>
    {
      var mediator = provider.GetService<IMediator>();
      return new StaticFilesAuthenticationMiddleware(mediator, configuration);
    });

    return services;
  }

  public static IApplicationBuilder UseStaticFilesAuthentication(this IApplicationBuilder app) => app.UseMiddleware<StaticFilesAuthenticationMiddleware>();
}