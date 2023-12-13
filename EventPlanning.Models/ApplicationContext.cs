using EventPlanning.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
    public DbSet<Event> Events { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Sms> SmsEnumerable { get; set; }
    public DbSet<User> Users { get; set; }
}