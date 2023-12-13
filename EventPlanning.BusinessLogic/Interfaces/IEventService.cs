using EventPlanning.Common.DTOs;
using EventPlanning.Common.DTOs.EventDto;
using EventPlanning.Models.Models;

namespace EventPlanning.BusinessLogic.Interfaces;

public interface IEventService
{
    void Create(EventCreateDto eventCreateDto);

    EventGetDto Get(Identifier identifier);

    List<EventGetDto> GetAll();

    Event Get(int id);

    void ChangeNumberOfParticipants(Event eventModel);

    List<Event> GetAllForUser();
}