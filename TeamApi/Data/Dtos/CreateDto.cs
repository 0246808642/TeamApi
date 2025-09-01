using System.ComponentModel.DataAnnotations;

namespace TeamApi.Data.Dtos;

public class CreateDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }
    [Required]
    [Range(3, 1000)]
    public int Age { get; set; }
    [StringLength(300)]
    public string Description { get; set; }
    
}
