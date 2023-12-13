using EventPlanning.Models.Models;

namespace EventPlanning.DAL.Interfaces;

public interface IUserRepository
{
    void Create(User user);

    User Get(string phoneNumber, string password);

    User Get(int id);
    
    User Get(string phoneNumber);

    void Change(User user);
}