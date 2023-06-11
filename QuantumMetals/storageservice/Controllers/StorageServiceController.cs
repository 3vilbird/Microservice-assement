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

    /// <summary>
    /// End point to get all the unique codes from the DB 
    /// </summary>
    /// <returns>list of unique codes</returns>
    [HttpGet]
    public async Task<IActionResult> Storage()
    {
        var result = await _storageService.ReadData();
        return Ok(result);
    }

    /// <summary>
    /// End point to store the data in the db
    /// </summary>
    /// <param name="lstUniqueCode"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Storage(List<UniqueCode> lstUniqueCode)
    {
        var result = _storageService.AddData(lstUniqueCode);
        return Ok(result);
    }
}
