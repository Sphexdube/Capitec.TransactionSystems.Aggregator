namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.TokenSecurity
{
    [Serializable]
    public sealed record TokenSecurityConfiguration
    {
        public required JwtTokenSecurityConfiguration Jwt { get; init; }
    }
}
