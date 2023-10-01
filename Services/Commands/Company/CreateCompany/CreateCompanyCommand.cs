namespace Services.Commands.Company.CreateCompany;

public class CreateCompanyCommand
{
    public string Cnpj { get; set; }
    public string Name { get; set; }

    public Domain.Entities.Company ToEntity()
    {
        return new()
        {
            Name = this.Name,
            Cnpj = this.Cnpj
        };
    }
}