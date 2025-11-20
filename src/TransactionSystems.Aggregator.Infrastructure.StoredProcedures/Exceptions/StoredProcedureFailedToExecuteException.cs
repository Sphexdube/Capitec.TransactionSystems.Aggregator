using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace TransactionSystems.Aggregator.Infrastructure.StoredProcedures.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public sealed class StoredProcedureFailedToExecuteException : Exception
    {
        public StoredProcedureFailedToExecuteException()
        {
        }

        public StoredProcedureFailedToExecuteException(string? message) : base(message)
        {
        }

        public StoredProcedureFailedToExecuteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        [Obsolete(DiagnosticId = "SYSLIB0051")]
        [SuppressMessage("Major Code Smell", "S1133:Do not forget to remove this deprecated code someday",
            Justification = "This is required based on serializable")]
        private StoredProcedureFailedToExecuteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
