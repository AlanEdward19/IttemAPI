using Domain.Interfaces;
using Services.Queries.Instructor.GetInstructor;
using Services.ViewModels;

namespace Services.Queries.Login;

public class LoginQueryHandler
{
    private readonly GetInstructorQueryHandler _queryHandler;
    private readonly IAuthService _authService;

    public LoginQueryHandler(GetInstructorQueryHandler queryHandler, IAuthService authService)
    {
        _queryHandler = queryHandler;
        _authService = authService;
    }

    public async Task<LoginViewModel> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(query.Password);

        var user = await _queryHandler.GetByEmailAndPassword(query.Email, passwordHash);

        if (user == null)
        {
            return null;
        }

        var token = _authService.GenerateJwtToken(user.Email, user.Role);

        return new()
        {
            Email = user.Email,
            Token = token
        };
    }
}