using Authorization_Code_Flow.Api.Interfaces;
using Authorization_Code_Flow.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authorization_Code_Flow.Api.Controllers;

[ApiController]
[Route("idp")]
public class IdpController : ControllerBase
{
    private readonly IIdpService _idpService;

    public IdpController(IIdpService idpService)
    {
        _idpService = idpService;
    }

    [HttpGet("settings")]
    public async Task<IActionResult> GetIdpSettings()
    {
        return Ok(await _idpService.GetIdpSettings());
    }

    [HttpPost("users/register")]
    public async Task<IActionResult> RegisterUserAsync(UserModel user)
    {
        return Ok(await _idpService.RegisterUserAsync(user));
    }

}
