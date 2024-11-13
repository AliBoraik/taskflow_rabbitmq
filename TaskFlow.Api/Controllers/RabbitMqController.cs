using Microsoft.AspNetCore.Mvc;
using TaskFlow.Interfaces;

namespace TaskFlow.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RabbitMqController : ControllerBase
{
    private readonly IRabbitMqService _rabbitMqService;

    public RabbitMqController(IRabbitMqService rabbitMqService)
    {
        _rabbitMqService = rabbitMqService;
    }

    [Route("[action]/{message}")]
    [HttpGet]
    public IActionResult SendMessage(string message)
    {
       try
       {
           _rabbitMqService.SendMessage(message);
           return Ok("The message has been sent");
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           return StatusCode(StatusCodes.Status500InternalServerError ,  "Internal server error. Please retry later.");
       }
    }
}