namespace Zahradneek.Api.Models;

public class News: BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
    public User Author { get; set; }
    public int AuthorId {get; set; }
}