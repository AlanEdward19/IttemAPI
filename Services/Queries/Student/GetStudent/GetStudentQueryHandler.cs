using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;

namespace Services.Queries.Student.GetStudent;

public class GetStudentQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetStudentQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<StudentViewModel>> Get(string? cpf)
    {
        List<StudentViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(cpf)
            ? await _dbContext.Students.Include(x => x.Company).Include(x => x.Class).Include(x => x.Function)
                .Include(x => x.Polo).ToListAsync()
            : await _dbContext.Students.Include(x => x.Company).Include(x => x.Class).Include(x => x.Function)
                .Include(x => x.Polo).Where(x => x.Cpf.Equals(cpf))
                .ToListAsync();

        foreach (var student in database)
        {
            result.Add(new()
            {
                Cpf = student.Cpf,
                AdmissionDate = student.AdmissionDate,
                BirthDate = student.BirthDate,
                City = student.City,
                ClassId = student.ClassId,
                ClassName = student.Class.Name,
                CompanyId = student.CompanyId,
                CompanyName = student.Company.Name,
                ContractPeriod = student.ContractPeriod,
                DayOfTrainingWeek = student.DayOfTrainingWeek.ToString(),
                EndDate = student.EndDate,
                FinalDayTrainingIntroduction = student.FinalDayTrainingIntroduction,
                FirstDayOfTrainingIntroduction = student.FirstDayOfTrainingIntroduction,
                FirstDayOfWeeklyTraining = student.FirstDayOfWeeklyTraining,
                FunctionId = student.FunctionId,
                FunctionName = student.Function.Name,
                Model = student.Model.ToString(),
                Name = student.Name,
                ReasonForTermination = student.ReasonForTermination.ToString(),
                PhoneNumber = student.PhoneNumber,
                PoloId = student.PoloId,
                PoloName = student.Polo.Name,
                PracticeHours = student.PracticeHours,
                ScheduleTrainingInitialEFinal = student.ScheduleTrainingInitialEFinal,
                Status = student.Status ? "Ativo" : "Inativo",
                TheoreticalHours = student.TheoreticalHours
            });
        }

        return result;
    }

    public async Task<IEnumerable<StudentViewModel>> GetStudentByClass(string? classId)
    {
        List<StudentViewModel> result = new();
        var database = string.IsNullOrWhiteSpace(classId)
            ? await _dbContext.Students.Include(x => x.Company).Include(x => x.Class).Include(x => x.Function)
                .Include(x => x.Polo).ToListAsync()
            : await _dbContext.Students.Include(x => x.Company).Include(x => x.Class).Include(x => x.Function)
                .Include(x => x.Polo).Where(x => x.ClassId.Equals(Guid.Parse(classId)))
                .ToListAsync();

        foreach (var student in database)
        {
            result.Add(new()
            {
                Cpf = student.Cpf,
                AdmissionDate = student.AdmissionDate,
                BirthDate = student.BirthDate,
                City = student.City,
                ClassId = student.ClassId,
                ClassName = student.Class.Name,
                CompanyId = student.CompanyId,
                CompanyName = student.Company.Name,
                ContractPeriod = student.ContractPeriod,
                DayOfTrainingWeek = student.DayOfTrainingWeek.ToString(),
                EndDate = student.EndDate,
                FinalDayTrainingIntroduction = student.FinalDayTrainingIntroduction,
                FirstDayOfTrainingIntroduction = student.FirstDayOfTrainingIntroduction,
                FirstDayOfWeeklyTraining = student.FirstDayOfWeeklyTraining,
                FunctionId = student.FunctionId,
                FunctionName = student.Function.Name,
                Model = student.Model.ToString(),
                Name = student.Name,
                ReasonForTermination = student.ReasonForTermination.ToString(),
                PhoneNumber = student.PhoneNumber,
                PoloId = student.PoloId,
                PoloName = student.Polo.Name,
                PracticeHours = student.PracticeHours,
                ScheduleTrainingInitialEFinal = student.ScheduleTrainingInitialEFinal,
                Status = student.Status ? "Ativo" : "Inativo",
                TheoreticalHours = student.TheoreticalHours
            });
        }

        return result;
    }
}