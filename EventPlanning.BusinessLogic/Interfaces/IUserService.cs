using EventPlanning.Common.DTOs.AuthDto;
using EventPlanning.Models.Models;

namespace EventPlanning.BusinessLogic.Interfaces;

public interface IUserService
{
    void Create(UserRegisterDto userRegisterDto);

    User Get(string phoneNumber, string password);

    User Get(string phoneNumber);

    void Change(string phoneNumber);
}