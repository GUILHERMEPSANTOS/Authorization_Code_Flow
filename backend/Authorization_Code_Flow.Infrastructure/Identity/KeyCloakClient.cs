using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace Authorization_Code_Flow.Infrastructure.Identity
{
    public class KeyCloakClient(HttpClient _httpClient, IOptions<KeyCloakOptions> options)
          : IKeyCloakClient
    {
        public async Task<IdpSettings> GetIdpSettings()
        {
            var keycloakOptions = options.Value;
            var httpResponseMessage = await _httpClient.GetAsync(keycloakOptions.WellKnown);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            var idpSettings = await DeserializeResponse<IdpSettings>(httpResponseMessage);

            idpSettings.WellKnown = keycloakOptions.WellKnown;

            return idpSettings;
        }

        public async Task<string> RegisterUserAsync(UserRepresentation user, CancellationToken cancellationToken = default)
        {
            _httpClient.BaseAddress = new Uri(options.Value.AdminUrl);

            var httpResponseMessage = await _httpClient.PostAsJsonAsync("users", user, cancellationToken);

            httpResponseMessage.EnsureSuccessStatusCode();

            return ExtractIdentityIdFromLocationHeader(httpResponseMessage);
        }

        private static string ExtractIdentityIdFromLocationHeader(HttpResponseMessage httpResponseMessage)
        {
            const string userSegmentName = "users/";

            var locationHeader = httpResponseMessage.Headers.Location?.PathAndQuery;
            if (locationHeader is null)
                throw new InvalidOperationException("Location header is null");

            var userSegmentValueIndex = locationHeader.IndexOf(userSegmentName, StringComparison.InvariantCultureIgnoreCase);

            var identityId = locationHeader[(userSegmentValueIndex + userSegmentName.Length)..];

            return identityId;
        }

        private async Task<Response> DeserializeResponse<Response>(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var responseAsString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Response>(responseAsString, options);
        }
    }
}
