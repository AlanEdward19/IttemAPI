using Domain.Enums;

namespace Services.Commands.Attendance.CreateAttendance;

public class CreateAttendanceCommand
{
    public string StudentCpf { get; set; }
    public string Level { get; set; }
    public string Module { get; set; }
    public EAttendance Type { get; set; }
    public DateTime AttendanceDate { get; set; }

    public Domain.Entities.Attendance ToEntity()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            StudentId = this.StudentCpf,
            Level = this.Level,
            Module = this.Module,
            Type = this.Type,
            Date = DateTime.SpecifyKind(AttendanceDate, DateTimeKind.Utc)
        };
    }
}