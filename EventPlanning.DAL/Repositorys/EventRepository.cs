using EventPlanning.Common.DTOs;
using EventPlanning.DAL.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.Models;

namespace EventPlanning.DAL.Repositorys;

public class EventRepository : IEventRepository
{
    private readonly ApplicationContext _applicationContext;

    public EventRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Create(Event newEvent)
    {
        _applicationContext.Events.Add(newEvent);
        _applicationContext.SaveChanges();
    }
    
    public Event Get(Identifier identifier)
    {
        var getEvent = _applicationContext.Events.FirstOrDefault(e => e.Id == identifier.Id);

        return getEvent;
    }
    
    public List<Event> GetAll()
    {
        var getEvents = _applicationContext.Events.ToList();

        return getEvents;
    }

    public Event Get(int id)
    {
        var eventModel = _applicationContext.Events.FirstOrDefault(e => e.Id == id);

        return eventModel;
    }

    public void Edit(Event eventModel)
    {
        _applicationContext.Events.Update(eventModel);
        _applicationContext.SaveChanges();
    }
}