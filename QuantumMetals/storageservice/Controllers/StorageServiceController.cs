using Microsoft.AspNetCore.Mvc;
using storageservice.Models;
using storageservice.Service;

namespace storageservice.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class StorageServiceController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageServiceController(IStorageService service)
    {
        _storageService = service;
    }

    [HttpGet]
    public async Task<IActionResult> Storage()
    {
        var result = await _storageService.ReadData();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Storage(List<UniqueCode> lstUniqueCode)
    {
        var result = _storageService.AddData(lstUniqueCode);
        return Ok(result);
    }
}
