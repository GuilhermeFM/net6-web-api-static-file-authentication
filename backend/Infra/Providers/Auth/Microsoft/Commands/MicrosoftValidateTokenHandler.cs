using Providers.Auth.Microsoft.Common;

namespace Providers.Auth.Microsoft.Commands;

public class MicrosoftValidateTokenHandler : IRequestHandler<MicrosoftValidateTokenRequest, MicrosoftBaseResponse<MicrosoftTokenJwt>>
{
  #region PROPS

  private readonly MicrosoftConfigurations _configurations;

  #endregion

  #region CONSTRUCTORS

  public MicrosoftValidateTokenHandler(MicrosoftConfigurations configurations)
  {
    _configurations = configurations;
  }

  #endregion

  public async Task<MicrosoftBaseResponse<MicrosoftTokenJwt>> Handle(MicrosoftValidateTokenRequest request, CancellationToken cancellationToken)
  {
    var retriever = new OpenIdConnectConfigurationRetriever();
    var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(_configurations.Metadata, retriever);
    var configuration = await configurationManager.GetConfigurationAsync(cancellationToken);

    var validationParameters = new TokenValidationParameters()
    {
      ValidateIssuer = false,
      ValidateAudience = false,
      ValidateLifetime = false,
      IssuerSigningKeys = configuration.SigningKeys,
    };

    var validatedToken = new JwtSecurityTokenHandler().ValidateToken(request.TokenJWT, validationParameters, out _);

    return new MicrosoftBaseResponse<MicrosoftTokenJwt>
    {
      Payload = new MicrosoftTokenJwt
      {
        name = validatedToken.Claims.FirstOrDefault(currentClaim => currentClaim.Type == "preferred_username").Value,
        email = validatedToken.Claims.FirstOrDefault(currentClaim => currentClaim.Type == "preferred_username").Value,
        sub = validatedToken.Claims.FirstOrDefault(currentClaim => currentClaim.Type == ClaimTypes.NameIdentifier).Value,
      }
    };
  }
}
