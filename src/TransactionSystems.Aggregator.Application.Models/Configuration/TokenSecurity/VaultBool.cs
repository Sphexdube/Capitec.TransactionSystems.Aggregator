namespace TransactionSystems.Aggregator.Domain.Interfaces.Configuration.TokenSecurity
{
    public sealed class VaultBool
    {
        private static readonly IReadOnlyList<string> _enabledValues = ["yes", "enabled", "on", "1", "true"];
        public string StringValue { get; set; } = "false";
        public bool Value
        {
            get { return GetValue(); }
        }

        private bool GetValue()
        {
            return _enabledValues.Contains(StringValue.ToLowerInvariant());
        }
    }
}
