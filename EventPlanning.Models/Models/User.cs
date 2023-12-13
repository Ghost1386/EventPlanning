namespace EventPlanning.Models.Models;

public class User
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public int Age { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? Password { get; set; }
    
    public int Role { get; set; }
    
    public bool IsVerify { get; set; }
}