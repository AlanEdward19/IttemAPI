namespace Services.Commands.CertificateIssuance.CreateCertificate;

public class CreateCertificateCommand
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public DateTime DateOfIssue { get; set; }
}