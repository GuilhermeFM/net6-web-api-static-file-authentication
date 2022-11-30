using Providers.Auth.Microsoft.Common;

namespace Api;

internal class AppSettings
{
  public CorsConfigurations Cors { get; set; }
  public MicrosoftConfigurations Microsoft { get; set; }
}

internal class CorsConfigurations
{
  public string[] Origins { get; set; }
}