namespace EventPlanning.Common.DTOs.SmsDto;

public class SmsVerifyDto
{
    public string? PhoneNumber { get; set; }
    
    public int Code { get; set; }
}