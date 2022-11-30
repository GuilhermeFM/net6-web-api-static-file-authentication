namespace Providers.Auth.Microsoft.Common;

public class MicrosoftBaseResponse
{
  public string Message { get; set; }

  public bool Success => string.IsNullOrEmpty(Message);
}

public class MicrosoftBaseResponse<T> : MicrosoftBaseResponse where T : class
{
  public T Payload { get; set; }
}