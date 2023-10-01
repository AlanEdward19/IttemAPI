namespace Domain.Entities;

public class Company
{
    [Key]
    public string Cnpj { get; set; }
    public string Name { get; set; }

    public virtual IEnumerable<Student> Students { get; set; }
}