using EventPlanning.Common.DTOs.SmsDto;
using EventPlanning.DAL.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.DAL.Repositorys;

public class SmsRepository : ISmsRepository
{
    private readonly ApplicationContext _applicationContext;

    public SmsRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Create(Sms sms)
    {
        _applicationContext.SmsEnumerable.AddAsync(sms);
        _applicationContext.SaveChangesAsync();
    }

    public bool Verify(SmsVerifyDto smsVerifyDto)
    {
        var sms = _applicationContext.SmsEnumerable.FirstOrDefault(s => s.PhoneNumber == smsVerifyDto.PhoneNumber);

        return sms.Code == smsVerifyDto.Code;
    }
}