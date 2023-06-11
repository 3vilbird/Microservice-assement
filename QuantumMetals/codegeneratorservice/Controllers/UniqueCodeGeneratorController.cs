using codegeneratorservice.Service;
using Microsoft.AspNetCore.Mvc;

namespace codegeneratorservice.Controllers;

[ApiController]
[Route("[controller]")]
public class UniqueCodeGeneratorController : ControllerBase
{
    private readonly IUniqueCodeGenerator _uniqueCodeGeneratorService;

    public UniqueCodeGeneratorController(IUniqueCodeGenerator _service)
    {
        _uniqueCodeGeneratorService = _service;
    }
    [HttpGet(Name = "GenerateCodes")]
    public async Task<IActionResult> GenerateUniqueCode(int intCount)
    {
        var res = await _uniqueCodeGeneratorService.GenerateUniqueCode(intCount);
        return Ok(res);
    }

}
