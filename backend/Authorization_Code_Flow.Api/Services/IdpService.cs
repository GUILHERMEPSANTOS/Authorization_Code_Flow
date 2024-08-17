using System.Net.Http.Headers;
using Authorization_Code_Flow.Api.Interfaces;
using Authorization_Code_Flow.Infrastructure.Identity;


namespace Authorization_Code_Flow.Api.Services;

public class IdpService : IIdpService
{
    private readonly IIdentityProviderService _identityProviderService;

    public IdpService(IIdentityProviderService identityProviderService)
    {
        _identityProviderService = identityProviderService;
    }

    public async Task<IdpSettings> GetIdpSettings()
    {
        return await _identityProviderService.GetIdpSettings();
    }

    public async Task<string> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        return await _identityProviderService.RegisterUserAsync(user, cancellationToken); 
    }
}
