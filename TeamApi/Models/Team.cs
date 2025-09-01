using System.ComponentModel.DataAnnotations;

namespace TeamApi.Models;

public class Team
{
    [Key]
    [Required]
    public int Id  { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string? Name { get; set; }

    [Required]
    [Range(3, 1000)]
    public int Age { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; }
}
