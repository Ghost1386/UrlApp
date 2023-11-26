using System.ComponentModel.DataAnnotations;

namespace UrlApp.Common.DTOs;

public class CreateUrlDto
{
    [Required]
    [DataType(DataType.Url)]
    public string? LongUrl { get; set; }
}