using EventPlanning.Common.DTOs.SmsDto;

namespace EventPlanning.BusinessLogic.Interfaces;

public interface ISmsService
{
    void Send(string phoneNumber);

    bool Verify(SmsVerifyDto smsVerifyDto);
}