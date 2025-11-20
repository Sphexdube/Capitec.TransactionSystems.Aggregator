CREATE TABLE tblTransaction
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[DataSourceId] UNIQUEIDENTIFIER NOT NULL,
	[CategoryId] UNIQUEIDENTIFIER NULL,
	[PaymentMethodId] UNIQUEIDENTIFIER NULL,
	[ExternalTransactionId] NVARCHAR(100) NULL,
	[MerchantName] NVARCHAR(200) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[Amount] DECIMAL(18, 2) NOT NULL,
	[Currency] NVARCHAR(3) NOT NULL,
	[TransactionDate] DATETIMEOFFSET NOT NULL,
	[PostedDate] DATETIMEOFFSET NULL,
	[TransactionType] NVARCHAR(50) NOT NULL,
	[TransactionStatus] NVARCHAR(50) NOT NULL,
	[IsRecurring] BIT NOT NULL,
	[Tags] NVARCHAR(MAX) NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[ModifiedAt] DATETIMEOFFSET NULL,
	[ArchivedAt] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),

	CONSTRAINT PK_Transaction PRIMARY KEY (Id),

	INDEX IX_Transaction_CustomerId NONCLUSTERED (CustomerId),
	INDEX IX_Transaction_DataSourceId NONCLUSTERED (DataSourceId),
	INDEX IX_Transaction_CategoryId NONCLUSTERED (CategoryId),
	INDEX IX_Transaction_TransactionDate NONCLUSTERED (TransactionDate),
	INDEX IX_Transaction_ArchivedAt NONCLUSTERED (ArchivedAt)
)
