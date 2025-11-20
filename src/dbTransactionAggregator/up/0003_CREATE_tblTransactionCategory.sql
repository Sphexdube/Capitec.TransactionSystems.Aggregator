CREATE TABLE tblTransactionCategory
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[IconName] NVARCHAR(50) NULL,
	[ColorCode] NVARCHAR(7) NULL,
	[ParentCategoryId] UNIQUEIDENTIFIER NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
	[ModifiedAt] DATETIMEOFFSET NULL,
	[RowVersion] ROWVERSION,

	CONSTRAINT PK_TransactionCategory PRIMARY KEY (Id),
	CONSTRAINT UQ_TransactionCategory_Name UNIQUE (Name),
	CONSTRAINT FK_TransactionCategory_ParentCategory FOREIGN KEY (ParentCategoryId) REFERENCES tblTransactionCategory(Id),

	INDEX IX_TransactionCategory_Name NONCLUSTERED (Name),
	INDEX IX_TransactionCategory_ParentId NONCLUSTERED (ParentCategoryId)
)
