using System.Globalization;
using System.Security.Claims;
using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.Common.DTOs.AuthDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }
    
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        try
        {
            var user = _authService.Login(userLoginDto);

            if (user != null)
            {
                if (user.IsVerify)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Surname, user.Age.ToString()),
                        new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                        new Claim(ClaimTypes.Authentication, user.IsVerify.ToString()),
                    };
    
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity));
                
                    _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: user with " +
                                           $"{user.PhoneNumber} is signed id.");
            
                    return RedirectToAction("Index", "Event");
                }
            
                return RedirectToAction("Verify", "Sms");
            }

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {e.Message}");

            return BadRequest();
        }
    }
    
    public IActionResult Registration()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Registration(UserRegisterDto userRegisterDto)
    {
        try
        {
            _authService.Registration(userRegisterDto);
        
            HttpContext.Session.SetString("PhoneNumber", userRegisterDto.PhoneNumber);
        
            return RedirectToAction("Verify", "Sms");
        }
        catch (Exception e)
        {
            _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {e.Message}");

            return BadRequest();
        }
    }
}