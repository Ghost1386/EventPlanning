using System.Globalization;
using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.Common.DTOs.SmsDto;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.Controllers;

public class SmsController: Controller
{
    private readonly ISmsService _smsService;
    private readonly ILogger<SmsController> _logger;
    
    public SmsController(ISmsService smsService, ILogger<SmsController> logger)
    {
        _smsService = smsService;
        _logger = logger;
    }
    
    public IActionResult Verify()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Verify(SmsVerifyDto smsVerifyDto)
    {
        try
        {
            smsVerifyDto.PhoneNumber = HttpContext.Session.GetString("PhoneNumber");
        
            var isVerify = _smsService.Verify(smsVerifyDto);

            if (isVerify)
            {
                return RedirectToAction("Login", "Auth");
            }
        
            return RedirectToAction("Verify");
        }
        catch (Exception e)
        {
            _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {e.Message}");

            return BadRequest();
        }
    }
}