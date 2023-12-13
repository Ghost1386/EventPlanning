using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.Common.DTOs.EventDto;
using EventPlanning.DAL.Interfaces;
using EventPlanning.Models.Models;

namespace EventPlanning.BusinessLogic.Services;

public class RecordService : IRecordService
{
    private readonly IRecordRepository _recordRepository;
    private readonly IEventService _eventService;

    public RecordService(IRecordRepository recordRepository, IEventService eventService)
    {
        _recordRepository = recordRepository;
        _eventService = eventService;
    }

    public void Create(int userId, int eventId)
    {
        var eventModel = _eventService.Get(eventId);

        if (eventModel.AvailableParticipants != 0)
        {
            var newRecord = new Record
            {
                UserId = userId,
                EventId = eventId
            };
            
            _recordRepository.Create(newRecord);
            
            _eventService.ChangeNumberOfParticipants(eventModel);
        }
    }

    public List<EventGetDto> GetAllForUser(int id)
    {
        var records = _recordRepository.GetAllForUser(id);

        var events = _eventService.GetAllForUser();
        
        var recordsForUser = events.Where(e => e.Id == records
                .Select(r => r.EventId)
                .FirstOrDefault())
            .ToList();
        
        var eventGetDtos = recordsForUser.Select(getEvent => new EventGetDto
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
}