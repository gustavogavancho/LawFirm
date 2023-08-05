using LawFirm.Application.Contracts.Identity;
using LawFirm.Application.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LawFirm.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
    {
        return Ok(await _authenticationService.AuthenticateAsync(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
    {
        return Ok(await _authenticationService.RegisterAsync(request));
    }
}