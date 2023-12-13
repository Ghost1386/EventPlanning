namespace EventPlanning.Common.DTOs.EventDto;

public class EventCreateDto
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Location { get; set; }
    
    public DateTime DateAndTime { get; set; }
    
    public int TotalParticipants { get; set; }
}