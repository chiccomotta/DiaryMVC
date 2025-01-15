using System.ComponentModel.DataAnnotations;

namespace Diary.Domain.Models;

public class DiaryEntry
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(150)]
    public required string Title { get; set; }
    
    [Required]
    [MaxLength(1024)]
    public required string Content { get; set; }

    [Required]
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}