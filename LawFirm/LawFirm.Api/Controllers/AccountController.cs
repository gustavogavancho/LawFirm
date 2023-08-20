using LawFirm.Application.Contracts.Identity;
using LawFirm.Application.Models.Authentication;
using LawFirm.Identity.Models;
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

    [HttpGet("users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public async Task<ActionResult<List<ApplicationUser>>> GeUsersAsync()
    {
        return Ok(await _authenticationService.GetUsersAsync());
    }

    [HttpPost("changePassword")]
    [Authorize]
    public async Task<ActionResult<bool>> ChangePasswordAsync(ChangePasswordRequest changePasswordRequest)
    {
        return Ok(await _authenticationService.ChangePasswordAsync(changePasswordRequest.Id, changePasswordRequest.Password));
    }

    [Authorize]
    [HttpDelete("deleteUser/{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DeleteUserAsync(Guid id)
    {
        await _authenticationService.DeleteUserAsync(id.ToString());

        return NoContent();
    }
}