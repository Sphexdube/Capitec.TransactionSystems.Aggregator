IF NOT EXISTS (SELECT * FROM SYS.EXTENDED_PROPERTIES WHERE name = 'Contact Information')
BEGIN
	EXEC sys.sp_addextendedproperty @name=N'Contact Information', @value=N'Orchestration'
END
ELSE
BEGIN
	EXEC sys.sp_updateextendedproperty @name=N'Contact Information', @value=N'Orchestration'
END
GO

IF NOT EXISTS (SELECT * FROM SYS.EXTENDED_PROPERTIES WHERE name = 'Last Built User')
BEGIN
	EXEC sys.sp_addextendedproperty @name=N'Last Built User', @value=N'JD Duminy'
END
ELSE
BEGIN
	EXEC sys.sp_updateextendedproperty @name=N'Last Built User', @value=N'JD Duminy'
END
GO