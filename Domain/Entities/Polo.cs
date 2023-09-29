namespace Domain.Entities;

public class Polo
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}