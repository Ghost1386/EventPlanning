using EventPlanning.BusinessLogic.Interfaces;

namespace EventPlanning.BusinessLogic.Services;

public class GeneratorService : IGeneratorService
{
    public int Generate()
    {
        var rnd = new Random();
 
        var value = rnd.Next(100000, 999999);
        
        return value;
    }
}