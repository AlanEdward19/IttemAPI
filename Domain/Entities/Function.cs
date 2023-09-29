namespace Domain.Entities;

public class Function
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}