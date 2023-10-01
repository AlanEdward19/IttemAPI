namespace Domain.Entities;

public class CertificateIssuance
{
    public Guid Id { get; set; }
    [ForeignKey(nameof(Student))]
    public string StudentId { get; set; }
    public DateTime DateOfIssue { get; set; }

    public virtual Student Student { get; set; }
}