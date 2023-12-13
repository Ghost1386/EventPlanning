using EventPlanning.Common.DTOs;
using EventPlanning.DAL.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.Models;

namespace EventPlanning.DAL.Repositorys;

public class RecordRepository : IRecordRepository
{
    private readonly ApplicationContext _applicationContext;

    public RecordRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Create(Record newRecord)
    {
        _applicationContext.Records.Add(newRecord);
        _applicationContext.SaveChanges();
    }

    public List<Record> GetAllForUser(int id)
    {
        var records = _applicationContext.Records.Where(r => r.UserId == id)
            .ToList();

        return records;
    }
}