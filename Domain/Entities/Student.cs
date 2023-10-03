namespace Domain.Entities;

public class Student
{
    [Key]
    public string Cpf { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public DateTime BirthDate { get; set; }
    [ForeignKey(nameof(Company))]
    public string CompanyId { get; set; }
    [ForeignKey(nameof(Function))]
    public Guid FunctionId { get; set; }
    [ForeignKey(nameof(Class))]
    public Guid ClassId { get; set; }
    public int PracticeHours { get; set; }
    public int TheoreticalHours { get; set; }
    public EModel Model { get; set; }
    public EReasonForTermination ReasonForTermination { get; set; }
    public int ContractPeriod { get; set; }
    public bool Status { get; set; } //Ativo ou Inativo
    public string PhoneNumber { get; set; }
    [ForeignKey(nameof(Polo))]
    public Guid PoloId { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime AdmissionDate { get; set; }
    public int FirstDayOfTrainingIntroduction { get; set; }
    public int FinalDayTrainingIntroduction { get; set; }
    public int FirstDayOfWeeklyTraining { get; set; }
    public EWeekDay DayOfTrainingWeek { get; set; }
    public string ScheduleTrainingInitialEFinal { get; set; }


    public virtual Polo Polo { get; set; }
    public virtual Class Class { get; set; }
    public virtual Function Function { get; set; }
    public virtual Company Company { get; set; }

    public virtual IEnumerable<CertificateIssuance> CertificateIssuances { get; set; }
    public virtual IEnumerable<Attendance> Attendances { get; set; }
    public virtual IEnumerable<Assessment> Assessments { get; set; }

}