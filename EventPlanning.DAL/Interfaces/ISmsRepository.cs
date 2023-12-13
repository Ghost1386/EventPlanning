using EventPlanning.Common.DTOs.SmsDto;
using EventPlanning.Models.Models;

namespace EventPlanning.DAL.Interfaces;

public interface ISmsRepository
{
    void Create(Sms sms);

    bool Verify(SmsVerifyDto smsVerifyDto);
}