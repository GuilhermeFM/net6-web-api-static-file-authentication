using Providers.Auth.Microsoft.Common;

namespace Providers.Auth.Microsoft.Commands;

public class MicrosoftValidateTokenRequest : MicrosoftBaseRequest<MicrosoftBaseResponse<MicrosoftTokenJwt>>
{
  public string TokenJWT { get; set; }
}
