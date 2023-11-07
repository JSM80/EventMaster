using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/EventMaster")]
    public object Get()
    {
        return "Events";
        
        //testing
    }
}
