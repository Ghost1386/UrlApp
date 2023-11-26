namespace UrlApp.Models.Models;

public class Url
{
    public int Id { get; set; }
    
    public string? LongUrl { get; set; }
    
    public string? ShortenedUrl { get; set; }
    
    public DateTime DateOfCreation { get; set; }
    
    public int NumberOfTransitions { get; set; }
}