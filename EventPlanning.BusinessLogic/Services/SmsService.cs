using EventPlanning.BusinessLogic.Interfaces;
using EventPlanning.Common.DTOs.SmsDto;
using EventPlanning.DAL.Interfaces;
using EventPlanning.Models.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace EventPlanning.BusinessLogic.Services;

public class SmsService : ISmsService
{
    private const string AccountSid = "AC4012bf2fce72d52c23c42df366540e41";
    private const string AuthToken = "be45f143582f59a05623c1f1439da7b2";
    private const string TwilioPhoneNumber = "+12027914063";

    private readonly IGeneratorService _generatorService;
    private readonly ISmsRepository _smsRepository;
    private readonly IUserService _userService;

    public SmsService(IGeneratorService generatorService, ISmsRepository smsRepository, 
        IUserService userService)
    {
        _generatorService = generatorService;
        _smsRepository = smsRepository;
        _userService = userService;
    }

    public void Send(string phoneNumber)
    {
        TwilioClient.Init(AccountSid, AuthToken);
        
        var code = _generatorService.Generate();
        
        MessageResource.Create(
            body: $"Your code for registration {code}",
            from: new PhoneNumber(TwilioPhoneNumber),
            to: new PhoneNumber(phoneNumber));

        var sms = new Sms
        {
            PhoneNumber = phoneNumber,
            Code = code
        };
        
        _smsRepository.Create(sms);
    }

    public bool Verify(SmsVerifyDto smsVerifyDto)
    {
        var isVerify = _smsRepository.Verify(smsVerifyDto);

        if (isVerify)
        {
            _userService.Change(smsVerifyDto.PhoneNumber);
        }
        
        return isVerify;
    }
}