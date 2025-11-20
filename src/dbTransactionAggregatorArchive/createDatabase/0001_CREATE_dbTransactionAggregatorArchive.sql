IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE (name =  'dbTransactionAggregatorArchive')))
BEGIN
		DECLARE @FilePath varchar(300), @LogFilePath varchar(300), @FolderPrefix varchar(300)
		SELECT @FilePath = cast(SERVERPROPERTY('InstanceDefaultDataPath') as varchar(300))
		SELECT @LogFilePath = cast(SERVERPROPERTY('InstanceDefaultLogPath') as varchar(300))
		SELECT @FolderPrefix = 'dbTransactionAggregatorArchive\'

		SELECT @LogFilePath = REPLACE(@FilePath, '\Data1', '\Log1')

		EXEC (N'CREATE DATABASE [dbTransactionAggregatorArchive]
			ON PRIMARY ( NAME = N''dbTransactionAggregatorArchive'', FILENAME = N''' + @FilePath + @FolderPrefix + 'dbTransactionAggregatorArchive.mdf'' , SIZE = 250MB , MAXSIZE = UNLIMITED, FILEGROWTH = 250MB )
			LOG ON ( NAME = N''dbTransactionAggregatorArchive_log'', FILENAME = N''' + @LogFilePath + @FolderPrefix + 'dbTransactionAggregatorArchive.ldf'' , SIZE = 250MB , MAXSIZE = UNLIMITED , FILEGROWTH = 250MB )
				WITH CATALOG_COLLATION = DATABASE_DEFAULT')

		IF SERVERPROPERTY('EngineEdition') <> 5
		BEGIN
			ALTER DATABASE [dbTransactionAggregatorArchive] SET AUTO_CLOSE OFF WITH NO_WAIT;

			ALTER DATABASE [dbTransactionAggregatorArchive] SET RECOVERY SIMPLE WITH NO_WAIT;

			ALTER DATABASE [dbTransactionAggregatorArchive] SET READ_COMMITTED_SNAPSHOT ON;

			IF (@@servername LIKE '%PRD%')
    		BEGIN
    			ALTER DATABASE [dbTransactionAggregatorArchive] SET RECOVERY FULL WITH NO_WAIT;
    		END
		END
END
