using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RabbitMqController : ControllerBase
{
    [Route("[action]/{message}")]
    [HttpGet]
    public IActionResult SendMessage(string message)
    {
       try
       {
           // _mqService.SendMessage(message);
           return Ok("The message has been sent");
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           return StatusCode(StatusCodes.Status500InternalServerError ,  "Internal server error. Please retry later.");
       }
    }
}