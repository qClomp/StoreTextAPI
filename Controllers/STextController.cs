
using Microsoft.AspNetCore.Mvc;
using StoreTextAPI.Models;
using StoreTextAPI.Services;

namespace StoreTextAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class STextController : ControllerBase
{
    private readonly STextService _stextService;

    public STextController(STextService stextService) =>
        _stextService = stextService;

    [HttpGet]
    public async Task<List<SText>> Get() =>
        await _stextService.GetAsync();
    // public SText Get()
    // {
    //     Console.Write("Test");
    //     SText newSText = new SText
    //     {
    //         url = "TestURL",
    //         textdata = "TestTEXTDATA",
    //         filename = "TestFILENAME"
    //     };
    //     return newSText;
    // }

    [HttpGet("{id}")]
    public async Task<ActionResult<SText>> GetText(string id)
    {
        var stext = await _stextService.GetAsync(id);

        if (stext is null)
            return NotFound();

        return stext;
    }
    [HttpPost]
    public async Task<IActionResult> Post(SText newSText) 
    {
        await _stextService.CreateAsync(newSText);
        return CreatedAtAction(nameof(Get), new { url = newSText.url }, newSText);
    }
    // public async Task<int> Post(SText newSText)
    // {
    //     Console.WriteLine("in!");
    //     Console.WriteLine(newSText.filename);
    //     return 0;
    // }

        
}