namespace Authorization_Code_Flow.Infrastructure.Identity
{
    public interface IIdentityProviderService
    {
        public Task<IdpSettings> GetIdpSettings();
        Task<string> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
    }
}
