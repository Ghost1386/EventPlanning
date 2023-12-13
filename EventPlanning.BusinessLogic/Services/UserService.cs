using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.Common.DTOs.AuthDto;
using EventPlanning.DAL.Interfaces;
using EventPlanning.Models.Models;

namespace EventPlanning.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Create(UserRegisterDto userRegisterDto)
    {
        var newUser = new User
        {
            Name = userRegisterDto.Name,
            Age = userRegisterDto.Age,
            PhoneNumber = userRegisterDto.PhoneNumber,
            Password = userRegisterDto.Password,
            Role = 0,
            IsVerify = false
        };
        
        _userRepository.Create(newUser);
    }

    public User Get(string phoneNumber, string password)
    {
        var user = _userRepository.Get(phoneNumber, password);

        return user;
    }
    
    public User Get(string phoneNumber)
    {
        var user = _userRepository.Get(phoneNumber);

        return user;
    }

    public void Change(string phoneNumber)
    {
        var user = Get(phoneNumber);

        user.IsVerify = true;
        
        _userRepository.Change(user);
    }
}