using System.Text.Json.Serialization;

namespace Authorization_Code_Flow.Infrastructure.Identity;

public class IdpSettings
{
    public string WellKnown { get; set; }
    [JsonPropertyName("authorization_endpoint")]
    public string AuthorizationEndpoint { get; set; }
}