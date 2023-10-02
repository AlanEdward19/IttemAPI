namespace Services.ViewModels;

public class AssessmentViewModel
{
    public Guid Id { get; set; }
    public string StudentName { get; set; }
    public string StudentId { get; set; }
    public string Level { get; set; }
    public string Module { get; set; }
    public int SkillTechnique { get; set; }
    public int Participation { get; set; }
    public int InterpersonalRelationship { get; set; }
    public int GoalFulfillment { get; set; }
    public DateTime AssessmentDate { get; set; }
}