namespace Services.Commands.Attendance.CreateAttendance;

public class CreateAttendanceCommandHandler
{
    private readonly IttemContext _dbContext;

    public CreateAttendanceCommandHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<dynamic> CreateAttendance(CreateAttendanceCommand command)
    {
        var parsedEntity = command.ToEntity();
        await _dbContext.Attendances.AddAsync(parsedEntity);

        await _dbContext.SaveChangesAsync();

        return new
        {
            Operation = "Create",
            parsedEntity.Id,
            Type = parsedEntity.Type
        };
    }
}