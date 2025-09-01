using System.ComponentModel.DataAnnotations;

namespace TeamApi.Data.Dtos;

public class ReadTeamDtos
{
    public int Id { get; set; }
  
    public string Name { get; set; }

    public int Age { get; set; }
    public string? Description { get; set; }


    public DateTime LastConsult { get; set; } = DateTime.Now;
}
