


namespace Authorization_Code_Flow.Infrastructure.Identity;

public class IdentityProviderService(IKeyCloakClient _keyCloakClient) : IIdentityProviderService
{
    private const string PasswordCredentialType = "Password";
    public async Task<IdpSettings> GetIdpSettings()
    {
        return await _keyCloakClient.GetIdpSettings();
    }

    public async Task<string> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        var userRepresentation = new UserRepresentation(
           user.Email,
           user.Email,
           user.FirstName,
           user.LastName,
           true,
           true,
           [
               new CredentialRepresentation(PasswordCredentialType, user.Password, false)
           ]);

        return await _keyCloakClient.RegisterUserAsync(userRepresentation, cancellationToken);
    }
}