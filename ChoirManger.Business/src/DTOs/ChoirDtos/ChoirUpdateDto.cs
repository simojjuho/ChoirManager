namespace ChoirManger.Business.DTOs.ChoirDtos;

public class ChoirUpdateDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateOnly FoundedAt { get; set; }
}