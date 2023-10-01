namespace Domain.Entities;

public class Class
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    [ForeignKey(nameof(Instructor))]
    public Guid InstructorId { get; set; }

    public virtual Instructor Instructor { get; set; }
    public virtual IEnumerable<Student> Students { get; set; }
}