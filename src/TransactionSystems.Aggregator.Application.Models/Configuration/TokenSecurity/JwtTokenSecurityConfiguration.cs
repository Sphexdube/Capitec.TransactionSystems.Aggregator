namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.TokenSecurity
{
    [Serializable]
    public sealed record JwtTokenSecurityConfiguration
    {
        public required string Issuer { get; init; }
        public required string JwksUri { get; init; }
        public required string TokenHeader { get; init; }
        public required VaultBool VerifyCaGatewayToken { get; init; } = new VaultBool { StringValue = "true" };
    }
}
