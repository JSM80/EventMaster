﻿using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;

    public TicketController(ILogger<TicketController> logger)
    {
        _logger = logger;
    }
}
