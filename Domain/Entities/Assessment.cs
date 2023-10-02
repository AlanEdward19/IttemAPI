namespace Domain.Entities;

public class Assessment
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey(nameof(Student))]
    public string StudentId { get; set; }
    public string Level { get; set; }
    public string Module { get; set; }
    public int SkillTechnique { get; set; }
    public int Participation { get; set; }
    public int InterpersonalRelationship { get; set; }
    public int GoalFulfillment { get; set; }
    public DateTime AssessmentDate { get; set; }

    public virtual Student Student { get; set; }
}