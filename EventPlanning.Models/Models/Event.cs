﻿namespace EventPlanning.Models.Models;

public class Event
{
    public int Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Location { get; set; }
    
    public DateTime DateAndTime { get; set; }
    
    public int TotalParticipants { get; set; }
    
    public int AvailableParticipants { get; set; }
}