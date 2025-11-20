CREATE TABLE tblTransactionReversal
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[OriginalTransactionId] UNIQUEIDENTIFIER NOT NULL,
	[ReversalTransactionId] UNIQUEIDENTIFIER NOT NULL,
	[ReversalReason] NVARCHAR(500) NULL,
	[ReversalDate] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
	[CreatedAt] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
	[ModifiedAt] DATETIMEOFFSET NULL,
	[RowVersion] ROWVERSION,

	CONSTRAINT PK_TransactionReversal PRIMARY KEY (Id),
	CONSTRAINT FK_TransactionReversal_Original FOREIGN KEY (OriginalTransactionId) REFERENCES tblTransaction(Id),
	CONSTRAINT FK_TransactionReversal_Reversal FOREIGN KEY (ReversalTransactionId) REFERENCES tblTransaction(Id),
	CONSTRAINT UQ_TransactionReversal_Original UNIQUE (OriginalTransactionId),

	INDEX IX_TransactionReversal_OriginalId NONCLUSTERED (OriginalTransactionId),
	INDEX IX_TransactionReversal_ReversalId NONCLUSTERED (ReversalTransactionId)
)
