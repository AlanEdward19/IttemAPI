using Microsoft.EntityFrameworkCore;

namespace Services.Queries.CertificateIssuance.GetCertificateIssuance;

public class GetCertificateIssuanceQueryHandler
{
    private readonly IttemContext _dbContext;

    public GetCertificateIssuanceQueryHandler(IttemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CertificateIssuanceViewModel> Get(string cpf)
    {
        var database = await _dbContext.Students.Include(x => x.Company).Include(x => x.Function).Include(x => x.Attendances)
            .FirstOrDefaultAsync(x => x.Cpf.Equals(cpf));

        var quantity = database.Attendances.Count();

        bool isQualified = quantity != 0 && database.Attendances.Count(x => x.Type != EAttendance.Ausente) >=
            (int) Math.Ceiling(quantity * 0.75);

        return new()
        {
            CompanyName = database.Company.Name,
            StudentCpf = database.Cpf,
            StudentFunction = database.Function.Name,
            FinalDate = database.EndDate.ToString("dd/MM/yyyy"),
            InitialDate = database.AdmissionDate.ToString("dd/MM/yyyy"),
            IsQualified = isQualified
        };
    }
}