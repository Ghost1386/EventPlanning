using EventPlanning.Common.DTOs.AuthDto;
using EventPlanning.Models.Models;

namespace EventPlanning.BusinessLogic.Interfaces;

public interface IAuthService
{
    User Login(UserLoginDto userLoginDto);
    
    void Registration(UserRegisterDto userRegisterDto);
}