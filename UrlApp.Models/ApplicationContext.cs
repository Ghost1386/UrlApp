using Microsoft.EntityFrameworkCore;
using UrlApp.Models.Models;

namespace UrlApp.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
    public DbSet<Url> Urls { get; set; }
}