using Domain.Enums;

namespace Services.Commands.Student.CreateStudent;
public class CreateStudentCommand
{
    public string Cpf { get; set; }
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

    public Domain.Entities.Student ToEntity()
    {
        return new()
        {
            Cpf = Cpf,
            Name = Name,
            City = City,
            BirthDate = DateTime.SpecifyKind(BirthDate, DateTimeKind.Utc),
            CompanyId = CompanyCnpj,
            FunctionId = FunctionId,
            ClassId = ClassId,
            PracticeHours = PracticeHours,
            TheoreticalHours = TheoreticalHours,
            Model = Model,
            ReasonForTermination = ReasonForTermination,
            ContractPeriod = ContractPeriod,
            Status = Status,
            PhoneNumber = PhoneNumber,
            PoloId = PoloId,
            EndDate = DateTime.SpecifyKind(EndDate, DateTimeKind.Utc),
            AdmissionDate = DateTime.SpecifyKind(AdmissionDate, DateTimeKind.Utc),
            FirstDayOfTrainingIntroduction = FirstDayOfTrainingIntroduction,
            FinalDayTrainingIntroduction = FinalDayTrainingIntroduction,
            FirstDayOfWeeklyTraining = FirstDayOfWeeklyTraining,
            DayOfTrainingWeek = DayOfTrainingWeek,
            ScheduleTrainingInitialEFinal = ScheduleTrainingInitialEFinal
        };
    }
}