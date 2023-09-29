namespace Domain.Entities;

public class Instructor
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhotoPath { get; set; }
}