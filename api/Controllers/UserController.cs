using api.TransferModels;
using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using service;

namespace api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet("/api/Users")]
    public ResponseDto GetById(int id)
    {
        return new ResponseDto
        {
            MessageToClient = "Successfully fetched",
            ResponseData = _service.GetById(id)
        };
    }
    


    /*
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
    */

}
