SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TransactionSystems Team
-- Create date: 2025/11/18
-- Description:	Archives transaction data older than 6 months to the archive database
-- =============================================
CREATE OR ALTER PROCEDURE usp_ArchiveData
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @BatchSize INT = 5000;
	DECLARE @RowsAffected INT = 1;
	DECLARE @CurrentDate DATETIME = GETDATE();
	DECLARE @SixMonthsAgo DATETIME = DATEADD(MONTH, -6, @CurrentDate);

    BEGIN TRY
        WHILE @RowsAffected > 0
        BEGIN
			BEGIN TRANSACTION

			SET @RowsAffected = 0;

			-- =============================================
			-- Archive Transactions older than 6 months
			-- =============================================
			SELECT TOP (@BatchSize) t.*
			INTO #Transactions
			FROM dbTransactionAggregator.dbo.tblTransaction t WITH(NOLOCK)
			WHERE t.TransactionDate < @SixMonthsAgo;

			INSERT INTO dbTransactionAggregatorArchive.dbo.tblTransaction
			SELECT *
			FROM #Transactions;

			DELETE TOP (@BatchSize) t1
			FROM dbTransactionAggregator.dbo.tblTransaction t1
			INNER JOIN #Transactions t2 ON t1.Id = t2.Id;

			SET @RowsAffected = @@ROWCOUNT;

			DROP TABLE #Transactions;
			-- =============================================
			-- END tblTransaction
			-- =============================================

			-- =============================================
			-- Archive TransactionReversals
			-- =============================================
			SELECT TOP (@BatchSize) tr.*
			INTO #TransactionReversals
			FROM dbTransactionAggregator.dbo.tblTransactionReversal tr WITH(NOLOCK)
			WHERE tr.ReversalDate < @SixMonthsAgo;

			INSERT INTO dbTransactionAggregatorArchive.dbo.tblTransactionReversal
			SELECT *
			FROM #TransactionReversals;

			DELETE TOP (@BatchSize) tr1
			FROM dbTransactionAggregator.dbo.tblTransactionReversal tr1
			INNER JOIN #TransactionReversals tr2 ON tr1.Id = tr2.Id;

			SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

			DROP TABLE #TransactionReversals;
			-- =============================================
			-- END tblTransactionReversal
			-- =============================================

			-- =============================================
			-- Archive disconnected CustomerDataSources
			-- =============================================
			SELECT TOP (@BatchSize) cds.*
			INTO #CustomerDataSources
			FROM dbTransactionAggregator.dbo.tblCustomerDataSource cds WITH(NOLOCK)
			WHERE cds.IsConnected = 0
			  AND cds.ModifiedAt < @SixMonthsAgo;

			INSERT INTO dbTransactionAggregatorArchive.dbo.tblCustomerDataSource
			SELECT *
			FROM #CustomerDataSources;

			DELETE TOP (@BatchSize) cds1
			FROM dbTransactionAggregator.dbo.tblCustomerDataSource cds1
			INNER JOIN #CustomerDataSources cds2 ON cds1.Id = cds2.Id;

			SET @RowsAffected = @RowsAffected + @@ROWCOUNT;

			DROP TABLE #CustomerDataSources;
			-- =============================================
			-- END tblCustomerDataSource
			-- =============================================

			COMMIT TRANSACTION

			IF @RowsAffected = 0
				SELECT CAST(1 AS BIT) AS Result;
        END;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END
GO
