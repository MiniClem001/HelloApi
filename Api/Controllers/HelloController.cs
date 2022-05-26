using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    private readonly IGreetter _greeter;

    public HelloController(IGreetter helloService)
    {
        _greeter = helloService;
    }

    [HttpGet("greet")]
    public HelloModel GetGreetings()
    {
        return _greeter.Greet(null);
    }

    [HttpGet("greet/{name}")]
    public HelloModel GetGreetingsFor(string name)
    {
        return _greeter.Greet(name);
    }

    [HttpGet("history")]
    public List<HelloModel> GetHistory()
    {
        return _greeter.History;
    }

    [HttpGet("history/{name}")]
    public ActionResult<List<HelloModel>> GetHistoryFor(string name)
    {
        var history = _greeter.History
            .Where(greeter => greeter.Name == name)
            .ToList();

        var isUserInHistory = history.Any();
        if (!isUserInHistory)
        {
            return NotFound();
        }

        return Ok(history);
    }

    [HttpDelete("history/{name}")]
    public IActionResult DeleteHistoryFor(string name)
    {
        var greetingsRemovedCount = _greeter.History.RemoveAll(greeter => greeter.Name == name);
        var isUserInHistory = greetingsRemovedCount > 0;

        return isUserInHistory
            ? NoContent()
            : NotFound();
    }
}
