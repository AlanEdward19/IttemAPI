using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;

namespace Services.Queries.Attendance.GetAttendance;

public class GetAttendanceQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetAttendanceQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<AttendanceViewModel>> Get(string? studentId)
    {
        List<AttendanceViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(studentId)
            ? await _dbContext.Attendances.Include(x => x.Student).ToListAsync()
            : await _dbContext.Attendances.Include(x => x.Student).Where(x => x.StudentId.Equals(studentId))
                .ToListAsync();
        
        foreach (var attendance in database)
        {
            result.Add(new()
            {
                Id = attendance.Id,
                StudentId = attendance.StudentId,
                Level = attendance.Level,
                Module = attendance.Module,
                StudentName = attendance.Student.Name,
                Date = attendance.Date,
                Type = attendance.Type.ToString()
            });
        }

        return result;
    }
}