using Domain.Enums;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Services.Commands.Student.CreateStudent;
public class UpdateStudentCommand
{
    public string Name { get; set; }
    public string City { get; set; }
    public DateTime BirthDate { get; set; }
    public string CompanyCnpj { get; set; }
    public Guid FunctionId { get; set; }
    public Guid ClassId { get; set; }
    public int PracticeHours { get; set; }
    public int TheoreticalHours { get; set; }
    public EModel Model { get; set; }
    public EReasonForTermination ReasonForTermination { get; set; }
    public int ContractPeriod { get; set; }
    public bool Status { get; set; } //Ativo ou Inativo
    public string PhoneNumber { get; set; }
    public Guid PoloId { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime AdmissionDate { get; set; }
    public int FirstDayOfTrainingIntroduction { get; set; }
    public int FinalDayTrainingIntroduction { get; set; }
    public int FirstDayOfWeeklyTraining { get; set; }
    public EWeekDay DayOfTrainingWeek { get; set; }
    public string ScheduleTrainingInitialEFinal { get; set; }

    public async Task<Domain.Entities.Student> ToEntity(IttemContext context, string cpf)
    {
        var user = await context.Students.FirstAsync(x => x.Cpf.Equals(cpf));

        user.Name = Name;
        user.City = City;
        user.BirthDate = DateTime.SpecifyKind(BirthDate, DateTimeKind.Utc);
        user.CompanyId = CompanyCnpj;
        user.FunctionId = FunctionId;
        user.ClassId = ClassId;
        user.PracticeHours = PracticeHours;
        user.TheoreticalHours = TheoreticalHours;
        user.Model = Model;
        user.ReasonForTermination = ReasonForTermination;
        user.ContractPeriod = ContractPeriod;
        user.Status = Status;
        user.PhoneNumber = PhoneNumber;
        user.PoloId = PoloId;
        user.EndDate = DateTime.SpecifyKind(EndDate, DateTimeKind.Utc);
        user.AdmissionDate = DateTime.SpecifyKind(AdmissionDate, DateTimeKind.Utc);
        user.FirstDayOfTrainingIntroduction = FirstDayOfTrainingIntroduction;
        user.FinalDayTrainingIntroduction = FinalDayTrainingIntroduction;
        user.FirstDayOfWeeklyTraining = FirstDayOfWeeklyTraining;
        user.DayOfTrainingWeek = DayOfTrainingWeek;
        user.ScheduleTrainingInitialEFinal = ScheduleTrainingInitialEFinal;

        return user;
    }
}