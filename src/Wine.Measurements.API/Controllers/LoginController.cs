using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wine.Measurements.API.DTO;
using Wine.Measurements.Common.Data;
using Wine.Measurements.Common.Models;
using Wine.Measurements.Security.Common;

namespace Wine.Measurements.API.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]

public class LoginController : Controller
{
    private readonly IJwtAuthenticator _authenticator;
    private readonly IUserRepository _repository;

    public LoginController(IJwtAuthenticator authenticator, IUserRepository repository)
    {
        _authenticator = authenticator;
        _repository = repository;
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult Login([FromBody] LoginUserDTO user)
    {
        if (_repository.GetUser(user.UserName, user.PasswordHash) == null)
        {
            return Unauthorized();
        }

        return Ok();
    }

    [AllowAnonymous]
    [HttpGet("token")]
    public ActionResult Token([FromBody] LoginUserDTO user)
    {
        var validUser = _repository.GetUser(user.UserName, user.PasswordHash);

        if (validUser == null)
        {
            return Unauthorized();
        }

        var token = _authenticator.Authorize(validUser.FullName, validUser.UserName);
        return Ok(token);
    }
}
