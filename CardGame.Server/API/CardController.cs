using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.Server.API;
[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public CardController(IWebHostEnvironment env)
    {
        _env = env;
    }

    // GET Card by name String
    [HttpGet("{name}")]
    public IActionResult Card([FromRoute] string name)
    {
        name = name.ToUpperInvariant();
        if (!Constants.Lookups.CardLocations.TryGetValue(name, out var cardFile)) return BadRequest("File Not Found");
        string filePath = Path.Combine(_env.WebRootPath, Constants.Lookups.CardFolder, cardFile);
        if (!System.IO.File.Exists(filePath)) return NotFound("File Not Found");
        var fStream = new FileStream(filePath, FileMode.Open);
        return File(fStream ,"img/png");
    }
}