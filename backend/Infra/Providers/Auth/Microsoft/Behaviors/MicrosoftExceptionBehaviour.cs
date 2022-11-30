using Providers.Auth.Microsoft.Common;

namespace Providers.Auth.Microsoft.Behaviors;

public class MicrosoftExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  where TRequest : MicrosoftBaseRequest<TResponse>
  where TResponse : MicrosoftBaseResponse
{
  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    try
    {
      return await next();
    }
    catch
    {
      var response = Activator.CreateInstance(typeof(TResponse)) as TResponse;
      response.Message = "Erro while processing Google Provider call";
      return response;
    }
  }
}
