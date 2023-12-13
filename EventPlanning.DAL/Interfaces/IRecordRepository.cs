using EventPlanning.Common.DTOs;
using EventPlanning.Models.Models;

namespace EventPlanning.DAL.Interfaces;

public interface IRecordRepository
{
    void Create(Record record);

    List<Record> GetAllForUser(int id);
}