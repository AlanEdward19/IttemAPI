namespace Services.ViewModels;

public class AttendanceViewModel
{
    public Guid Id { get; set; }
    public string StudentName { get; set; }
    public string StudentId { get; set; }
    public string Level { get; set; }
    public string Module { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
}