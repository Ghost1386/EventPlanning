using System.Globalization;
using System.Security.Claims;
using EventPlanning.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.Controllers;

public class RecordController : Controller
{
    private readonly IRecordService _recordService;
    private readonly ILogger<RecordController> _logger;
    
    public RecordController(IRecordService recordService, ILogger<RecordController> logger)
    {
        _recordService = recordService;
        _logger = logger;
    }
    
    public IActionResult Create(int id)
    {
        try
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        
            _recordService.Create(userId, id);
        
            return RedirectToAction("Index", "Event");
        }
        catch (Exception e)
        {
            _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {e.Message}");

            return BadRequest();
        }
    }
}