IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE (name =  'dbTransactionAggregator')))
BEGIN
		DECLARE @FilePath varchar(300), @LogFilePath varchar(300), @FolderPrefix varchar(300)
		SELECT @FilePath = cast(SERVERPROPERTY('InstanceDefaultDataPath') as varchar(300))
		SELECT @LogFilePath = cast(SERVERPROPERTY('InstanceDefaultLogPath') as varchar(300))
		SELECT @FolderPrefix = 'dbTransactionAggregator\'

		SELECT @LogFilePath = REPLACE(@FilePath, '\Data1', '\Log1')

		EXEC (N'CREATE DATABASE [dbTransactionAggregator]
			ON PRIMARY ( NAME = N''dbTransactionAggregator'', FILENAME = N''' + @FilePath + @FolderPrefix + 'dbTransactionAggregator.mdf'' , SIZE = 250MB , MAXSIZE = UNLIMITED, FILEGROWTH = 250MB )
			LOG ON ( NAME = N''dbTransactionAggregator_log'', FILENAME = N''' + @LogFilePath + @FolderPrefix + 'dbTransactionAggregator.ldf'' , SIZE = 250MB , MAXSIZE = UNLIMITED , FILEGROWTH = 250MB )
				WITH CATALOG_COLLATION = DATABASE_DEFAULT')

		IF SERVERPROPERTY('EngineEdition') <> 5
		BEGIN
			ALTER DATABASE [dbTransactionAggregator] SET AUTO_CLOSE OFF WITH NO_WAIT;

			ALTER DATABASE [dbTransactionAggregator] SET RECOVERY SIMPLE WITH NO_WAIT;

			ALTER DATABASE [dbTransactionAggregator] SET READ_COMMITTED_SNAPSHOT ON;

			IF (@@servername LIKE '%PRD%')
    		BEGIN
    			ALTER DATABASE [dbTransactionAggregator] SET RECOVERY FULL WITH NO_WAIT;
    		END
		END
END