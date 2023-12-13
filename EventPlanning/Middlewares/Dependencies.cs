using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.BusinessLogic.Services;
using EventPlanning.DAL.Interfaces;
using EventPlanning.DAL.Repositorys;

namespace EventPlanning.Middlewares;

public static class Dependencies
{
    public static void AddIService(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IEventService, EventService>();
        services.AddTransient<IGeneratorService, GeneratorService>();
        services.AddTransient<IRecordService, RecordService>();
        services.AddTransient<ISmsService, SmsService>();
        services.AddTransient<IUserService, UserService>();
    }
    
    public static void AddIRepository(this IServiceCollection services)
    {
        services.AddTransient<IEventRepository, EventRepository>();
        services.AddTransient<IRecordRepository, RecordRepository>();
        services.AddTransient<ISmsRepository, SmsRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}