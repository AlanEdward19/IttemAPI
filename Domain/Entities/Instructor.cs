namespace Domain.Entities;

public class Instructor
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhotoPath { get; set; }
    public string Role { get; set; }

    public virtual IEnumerable<Class>? Classes { get; set; }
}