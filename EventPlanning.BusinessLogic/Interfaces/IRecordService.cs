using EventPlanning.Common.DTOs.EventDto;

namespace EventPlanning.BusinessLogic.Interfaces;

public interface IRecordService
{
    void Create(int userId, int eventId);

    List<EventGetDto> GetAllForUser(int id);
}