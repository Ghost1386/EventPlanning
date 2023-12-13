using EventPlanning.Common.DTOs;
using EventPlanning.Models.Models;

namespace EventPlanning.DAL.Interfaces;

public interface IEventRepository
{
    void Create(Event newEvent);

    Event Get(Identifier identifier);

    List<Event> GetAll();

    Event Get(int id);

    void Edit(Event eventModel);
}