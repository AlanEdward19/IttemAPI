namespace Services.Commands.Assessment.CreateAssessment;

public class CreateAssessmentCommand
{
    public string StudentCpf { get; set; }
    public string Level { get; set; }
    public string Module { get; set; }
    public int SkillTechnique { get; set; }
    public int Participation { get; set; }
    public int InterpersonalRelationship { get; set; }
    public int GoalFulfillment { get; set; }
    public DateTime AssessmentDate { get; set; }

    public Domain.Entities.Assessment ToEntity()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Level = this.Level,
            Module = this.Module,
            SkillTechnique = this.SkillTechnique,
            Participation = this.Participation,
            InterpersonalRelationship = this.InterpersonalRelationship,
            GoalFulfillment = this.GoalFulfillment,
            StudentId = StudentCpf,
            AssessmentDate = AssessmentDate
        };
    }
}