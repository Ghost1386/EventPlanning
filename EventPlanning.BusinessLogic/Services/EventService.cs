using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.Common.DTOs;
using EventPlanning.Common.DTOs.EventDto;
using EventPlanning.DAL.Interfaces;
using EventPlanning.Models.Models;

namespace EventPlanning.BusinessLogic.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public void Create(EventCreateDto eventCreateDto)
    {
        var newEvent = new Event
        {
            Title = eventCreateDto.Title,
            Description = eventCreateDto.Description,
            Location = eventCreateDto.Location,
            DateAndTime = eventCreateDto.DateAndTime,
            TotalParticipants = eventCreateDto.TotalParticipants,
            AvailableParticipants = eventCreateDto.TotalParticipants
        };

        _eventRepository.Create(newEvent);
    }

    public EventGetDto Get(Identifier identifier)
    {
        var getEvent = _eventRepository.Get(identifier);

        var eventGetDto = new EventGetDto
        {
            Id = getEvent.Id,
            Title = getEvent.Title,
            Description = getEvent.Description,
            Location = getEvent.Location,
            DateAndTime = getEvent.DateAndTime,
            TotalParticipants = getEvent.TotalParticipants,
            AvailableParticipants = getEvent.AvailableParticipants
        };

        return eventGetDto;
    }
    
    public List<EventGetDto> GetAll()
    {
        var getEvents = _eventRepository.GetAll();

        var eventGetDtos = getEvents.Select(getEvent => new EventGetDto
        {
            Id = getEvent.Id,
            Title = getEvent.Title,
            Description = getEvent.Description,
            Location = getEvent.Location,
            DateAndTime = getEvent.DateAndTime,
            TotalParticipants = getEvent.TotalParticipants,
            AvailableParticipants = getEvent.AvailableParticipants
        }).ToList();

        return eventGetDtos;
    }

    public Event Get(int id)
    {
        var eventModel = _eventRepository.Get(id);

        return eventModel;
    }
    
    public void ChangeNumberOfParticipants(Event eventModel)
    {
        eventModel.AvailableParticipants -= 1;
        
        _eventRepository.Edit(eventModel);
    }

    public List<Event> GetAllForUser()
    {
        var events = _eventRepository.GetAll();

        return events;
    }
}