using System.ComponentModel.DataAnnotations.Schema;

namespace Zahradneek.Api.Models;

public class BaseEntity
{
    [Column(Order = 0)]
    public Guid Id { get; set; } = new Guid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
}