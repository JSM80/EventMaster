using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/Api/User/Dummy")]
    public IActionResult dummy()
    {
        return Ok(new UserModel());
    }

    [HttpPost]
    [Route("/Api/User/Dummy")]
    public IActionResult dummy([FromBody] UserModel userModel)
    {
        return Ok(userModel);
    }
}
