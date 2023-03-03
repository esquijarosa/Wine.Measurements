using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wine.Measurements.API.DTO;
using Wine.Measurements.Common.Data;
using Wine.Measurements.Common.Models;

namespace Wine.Measurements.API.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]

public class RegistrationController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RegistrationController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetRegisteredUsers")]
    public ActionResult<IEnumerable<RegisteredUserDTO>> GetRegisteredUsers()
    {
        return Ok(_mapper.Map<IEnumerable<RegisteredUserDTO>>(_userRepository.GetRegisteredUsers()));
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult RegisterUser([FromBody] RegisterUserDTO user)
    {
        try
        {
            _userRepository.RegisterUser(_mapper.Map<User>(user));
        }
        catch (ArgumentException aex)
        {
            return BadRequest(aex.Message);
        }

        return Created("GetRegisteredUsers", null);
    }
}
