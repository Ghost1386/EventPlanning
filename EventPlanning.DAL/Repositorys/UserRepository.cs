using EventPlanning.DAL.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.Models;

namespace EventPlanning.DAL.Repositorys;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _applicationContext;

    public UserRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Create(User newUser)
    {
        _applicationContext.Users.Add(newUser);
        _applicationContext.SaveChanges();
    }

    public User Get(string phoneNumber, string password)
    {
        var user = _applicationContext.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber 
                                                                            && u.Password == password);

        return user;
    }

    public User Get(int id)
    {
        var user = _applicationContext.Users.FirstOrDefault(u => u.Id == id);

        return user;
    }

    public User Get(string phoneNumber)
    {
        var user = _applicationContext.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);

        return user;
    }

    public void Change(User user)
    {
        _applicationContext.Users.Update(user);
        _applicationContext.SaveChanges();
    }
}