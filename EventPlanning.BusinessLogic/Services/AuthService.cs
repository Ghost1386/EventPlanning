using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.Common.DTOs.AuthDto;
using EventPlanning.Models.Models;

namespace EventPlanning.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ISmsService _smsService;

    public AuthService(IUserService userService, ISmsService smsService)
    {
        _userService = userService;
        _smsService = smsService;
    }

    public User Login(UserLoginDto userLoginDto)
    {
        var user = _userService.Get(userLoginDto.PhoneNumber, userLoginDto.Password);

        return user;
    }

    public void Registration(UserRegisterDto userRegisterDto)
    {
        _userService.Create(userRegisterDto);
        
        _smsService.Send(userRegisterDto.PhoneNumber);
    }
}