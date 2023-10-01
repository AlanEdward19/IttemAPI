namespace Domain.Entities;

public class Attendance
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey(nameof(Student))]
    public string StudentId { get; set; }
    public string Level { get; set; }
    public string Module { get; set; }
    public EAttendance Type { get; set; }
    public DateTime Date { get; set; }

    public virtual Student Student { get; set; }
}