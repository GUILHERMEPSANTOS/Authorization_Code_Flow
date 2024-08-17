namespace Authorization_Code_Flow.Infrastructure.Identity;

public sealed record CredentialRepresentation(string Type, string Value, bool Temporary);