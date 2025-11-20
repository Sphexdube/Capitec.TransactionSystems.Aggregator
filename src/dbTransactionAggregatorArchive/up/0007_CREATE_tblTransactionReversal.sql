CREATE TABLE tblTransactionReversal
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[OriginalTransactionId] UNIQUEIDENTIFIER NOT NULL,
	[ReversalTransactionId] UNIQUEIDENTIFIER NOT NULL,
	[ReversalReason] NVARCHAR(500) NULL,
	[ReversalDate] DATETIMEOFFSET NOT NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[ModifiedAt] DATETIMEOFFSET NULL,
	[ArchivedAt] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),

	CONSTRAINT PK_TransactionReversal PRIMARY KEY (Id),

	INDEX IX_TransactionReversal_OriginalId NONCLUSTERED (OriginalTransactionId),
	INDEX IX_TransactionReversal_ReversalId NONCLUSTERED (ReversalTransactionId),
	INDEX IX_TransactionReversal_ArchivedAt NONCLUSTERED (ArchivedAt)
)
