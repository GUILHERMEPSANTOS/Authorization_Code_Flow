using Authorization_Code_Flow.Infrastructure.Identity;

namespace Authorization_Code_Flow.Api.Interfaces;

public interface IIdpService
{
    Task<IdpSettings> GetIdpSettings();
    Task<string> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
}
