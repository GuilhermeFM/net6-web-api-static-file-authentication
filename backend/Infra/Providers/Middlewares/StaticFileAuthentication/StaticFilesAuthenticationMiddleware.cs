using Providers.Auth.Microsoft.Commands;
using Providers.Middlewares.StaticFileAuthentication.Common;

namespace Providers.Middlewares.StaticFileAuthentication;

public class StaticFilesAuthenticationMiddleware : IMiddleware
{
  #region PROPS

  private readonly IMediator _mediator;
  private readonly StaticFilesAuthenticationConfiguration _configuration;

  #endregion

  #region CONSTRUCTORS

  public StaticFilesAuthenticationMiddleware(IMediator mediator, StaticFilesAuthenticationConfiguration configuration)
  {
    _mediator = mediator;
    _configuration = configuration;
  }

  #endregion

  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    if (context.Request.Path.StartsWithSegments(_configuration.Path))
    {
      var jwtToken = default(string);

      if (context.Request.Cookies.ContainsKey(_configuration.AccessTokenIdentifier))
      {
        jwtToken = context.Request.Cookies[_configuration.AccessTokenIdentifier];
      }

      if (string.IsNullOrEmpty(jwtToken))
      {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        return;
      }
      else
      {
        var result = await _mediator.Send(new MicrosoftValidateTokenRequest { TokenJWT = jwtToken });

        if (result == null || !result.Success)
        {
          context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
          return;
        }
        else
        {
          context.Response.Cookies.Delete(_configuration.AccessTokenIdentifier);
          context.Response.Cookies.Append(_configuration.AccessTokenIdentifier, jwtToken);

          await next(context);
        }
      }
    }
    else
    {
      await next(context);
    }
  }
}