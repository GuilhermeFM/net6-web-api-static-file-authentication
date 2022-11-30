using Providers.Auth.Microsoft.Commands;

namespace Api.Controllers;

[ApiController]
[Route("microsoft")]
public class MicrosoftAuthenticationController : ControllerBase
{
  #region DEPS

  private readonly IMediator _mediator;

  #endregion

  #region CONSTRUCTORS

  public MicrosoftAuthenticationController(IMediator mediator)
  {
    _mediator = mediator;
  }

  #endregion

  public async Task<IActionResult> Validate(MicrosoftValidateTokenRequest request)
  {
    return Ok(await _mediator.Send(request));
  }
}
