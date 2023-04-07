using System.ComponentModel.DataAnnotations.Schema;

namespace Zahradneek.Api.Models;

public class BaseEntity
{
    [Column(Order = 0)]
    public int Id { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
}