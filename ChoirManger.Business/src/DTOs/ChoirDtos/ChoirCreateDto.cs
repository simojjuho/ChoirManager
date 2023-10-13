namespace ChoirManger.Business.DTOs.ChoirDtos;

public class ChoirCreateDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateOnly? FoundedAt { get; set; }
    public string EmailAddresses { get; set; }
}