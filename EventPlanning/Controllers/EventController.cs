using System.Globalization;
using System.Security.Claims;
using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.Common.DTOs.EventDto;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.Controllers;

public class EventController : Controller
{
    private readonly IEventService _eventService;
    private readonly ILogger<EventController> _logger;
    
    public EventController(IEventService eventService, ILogger<EventController> logger)
    {
        _eventService = eventService;
        _logger = logger;
    }
    
    public IActionResult Create()
    {
        try
        {
            var userRole = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Role));
        
            if (userRole == 1)
            {
                return View();
            }

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {e.Message}");

            return BadRequest();
        }
    }
    
    [HttpPost]
    public IActionResult Create(EventCreateDto eventCreateDto)
    {
        try
        {
            _eventService.Create(eventCreateDto);

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {e.Message}");

            return BadRequest();
        }
    }
    
    public IActionResult Index()
    {
        try
        {
            var events = _eventService.GetAll();
        
            return View(events);
        }
        catch (Exception e)
        {
            _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {e.Message}");

            return BadRequest();
        }
    }
}